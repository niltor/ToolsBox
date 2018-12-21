using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace PostmanCollectionToPythonRequests.Models
{
    /// <summary>
    /// Api模型
    /// </summary>
    class PythonModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// 返回格式
        /// </summary>
        public string Common { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Introduction { get; set; }
        public List<PythonItem> Items { get; set; } = new List<PythonItem>();

        public Dictionary<string, string> Env { get; set; }
        /// <summary>
        /// 代码片段
        /// </summary>
        public string CodeBlock { get; set; }

        public PythonModel()
        {

        }

        /// <summary>
        /// 构建 python class内容
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public string BuildClassContent(List<Item> items, string folder = null)
        {
            var content = "";
            foreach (var item in items)
            {
                if (item.Children != null)
                {
                    // 构造目录
                    if (!string.IsNullOrEmpty(folder))
                    {
                        item.Name = folder + "-" + item.Name;
                    }
                    content += BuildClassContent(item.Children, item.Request.Url.Path?.Last() ?? "");
                }
                else
                {
                    var pythonItem = new PythonItem
                    {
                        Folder = folder,
                        Name = item.Request.Url.Path?.Last() ?? "",
                        Description = item.Request.Description,
                        Header = item.Request.Header,
                        Method = item.Request.Method,
                        Query = item.Request.Url.Query,
                        RequestBodyType = item.Request.Body?.Mode,
                        ResponseJson = item.Response?.FirstOrDefault()?.Body,
                        Url = item.Request.Url.Raw,
                        Path = string.Join('/', item.Request?.Url?.Path)
                    };

                    bool isJson = false;
                    //不同请求类型
                    switch (pythonItem.RequestBodyType)
                    {
                        case "formdata":
                            pythonItem.Params = item.Request.Body.Formdata;
                            break;
                        case "raw":
                            pythonItem.RequestRaw = item.Request.Body.Raw;
                            isJson = true;
                            break;
                        default:
                            pythonItem.Params = item.Request.Body.Urlencoded;
                            break;
                    }

                    Items.Add(pythonItem);
                    content += GetFunction(pythonItem.Name, pythonItem.Path, pythonItem.Method, isJson);
                    CodeBlock += GetRequestContent(pythonItem.Name, pythonItem.Query, pythonItem.Params, pythonItem.RequestRaw);
                }

            }
            return content;
        }

        /// <summary>
        /// 生成python类文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="items"></param>
        public void GenerateClassFile(string path, string name, string content)
        {
            // 获取接口内容
            content = GetImport() + GetServiceClass(name) + content;
            // 生成公共内容及导航
            var file = new FileInfo(path);
            if (!file.Exists) Directory.CreateDirectory(file.Directory.FullName);
            using (var writer = file.CreateText())
            {
                writer.Write(content);
            }
        }

        public void GenerateTestFile(string path, string name)
        {
            // 获取接口内容
            var content = GetCodeBlock(name, CodeBlock);
            // 生成公共内容及导航
            var file = new FileInfo(path);
            if (!file.Exists) Directory.CreateDirectory(file.Directory.FullName);
            using (var writer = file.CreateText())
            {
                writer.Write(content);
            }
        }

        #region text block 
        public string GetImport()
        {
            return "from Service import Service";
        }

        public string GetServiceClass(string name)
        {
            return $@"
class {name}Service(Service):
    def __init__(self, url=None, cookie=None, timeout=None):
        super().__init__(url, cookie, timeout)";
        }
        /// <summary>
        /// 获取函数代码
        /// </summary>
        /// <param name="name"></param>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="isJson"></param>
        /// <returns></returns>
        public string GetFunction(string name, string url, string method, bool isJson = false)
        {
            if (method.ToLower().Equals("get"))
            {
                return $@"
    def {name}(self, data=None, query=None):
        url = '{url}'
        if query:
            for (key, value) in query:
                url = url+key+'='+value+'&'
        return super().get(url)
";
            }
            else if (isJson)
            {

                return $@"
    def {name}(self, data, query=None):
        url = '{url}'
        if query:
            for (key, value) in query:
                url = url+key+'='+value+'&'
        return super().post(url, data=None, json=data)
";
            }
            else
            {
                return $@"
    def {name}(self, data, query=None):
        url = '{url}'
        if query:
            for (key, value) in query:
                url = url+key+'='+value+'&'
        return super().post(url, data=data, json=None)
";
            }
        }

        /// <summary>
        /// 获取请求代码
        /// </summary>
        /// <returns></returns>
        public string GetRequestContent(string name, List<Query> query, List<Params> param, string raw = "")
        {

            var block = "\r\n\tquery = {";
            if (query != null)
            {
                foreach (var item in query)
                {
                    block += $@"""{item.Key}"":"""", ";
                }
            }
            block += "}";
            block += "\r\n\tdata = {";
            if (param != null)
            {
                foreach (var item in param)
                {
                    block += $@"""{item.Key}"":"""", ";
                }
            }
            block += "}";
            block = block + "\r\n\tservice." + name + "(data,query)\r\n";
            return block;
        }

        public string GetCodeBlock(string className, string content)
        {
            className = className + "Service";
            return $@"from RequestServices.{className} import {className}


def run():
    test = {className}(url='', cookie={{}}, timeout=5)
" + content;
        }
        #endregion

    }
    public class PythonItem
    {
        /// <summary>
        /// 文件目录
        /// </summary>
        public string Folder { get; set; }

        public string Name { get; set; }
        public string Method { get; set; }

        public string Url { get; set; }
        /// <summary>
        /// 请求类型
        /// </summary>
        public string RequestBodyType { get; set; }
        /// <summary>
        /// 请求头
        /// </summary>
        public List<Header> Header { get; set; }
        /// <summary>
        /// 相对路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public List<Params> Params { get; set; }
        /// <summary>
        /// 请求query
        /// </summary>
        public List<Query> Query { get; set; }
        /// <summary>
        /// 请求内容
        /// </summary>
        public string RequestRaw { get; set; }

        public string Description { get; set; }

        public string ResponseJson { get; set; }

        public List<Params> ResponseFileds { get; set; }

    }



}
