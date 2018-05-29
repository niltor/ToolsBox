using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Test
{
    /// <summary>
    /// Api模型
    /// </summary>
    public class SwaggerApiModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// 本地地址
        /// </summary>
        public string LocalUrl { get; set; }
        /// <summary>
        /// 替换地址
        /// </summary>
        public string ReplaceUrl { get; set; }

        /// <summary>
        /// 返回格式
        /// </summary>
        public string Common { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 接口元素
        /// </summary>
        public List<SwaggerApiItem> Items { get; set; } = new List<SwaggerApiItem>();

        /// <summary>
        /// 对象定义
        /// </summary>
        public IDictionary<string, Schema> Definitions { get; set; }

        public Dictionary<string, string> Env { get; set; }

        public SwaggerApiModel()
        {

        }

        /// <summary>
        /// 一组接口内容
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public String GetItemsContent(List<SwaggerApiItem> items, string folder = null)
        {
            var content = "";
            foreach (var item in items)
            {
                // 地址处理
                if (!string.IsNullOrWhiteSpace(LocalUrl) && !string.IsNullOrWhiteSpace(ReplaceUrl))
                {
                    item.Url = ReplaceUrl + "/" + item.Url;
                }

                content += GetItemTitle(item.Name, item.OperationId)
                + GetRequestLine(item.Method, item.Url) + GetDescription(item.Description, item.Name)
                //+ GetHeader(item.Header) 
                + GetParams(item.Request)
                + GetResponse(item.Response);

            }
            content += GetDefinitions();
            return content;
        }

        /// <summary>
        /// 完整文档
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public string ToMarkdown(List<SwaggerApiItem> items)
        {
            // 获取接口内容
            var content = GetItemsContent(items, null);
            // 生成公共内容及导航
            content = GetTitle(Name) + GetInfo("Author:" + Author) + GetInfo("Email:" + Email) + Introduction + Common
                + GetNavgation(Items) + content;
            return content;
        }

        #region text block 
        private string GetQuery(List<Parameter> query)
        {
            if (query == null)
                return "";
            var result = "#### 请求query参数\r\n|键|值|类型|说明|\r\n|-|-|-|-|\r\n";
            //foreach (var item in query)
            //{
            //    var row = $"|{item.Key}|{item.Value}|{item.Value?.GetType().ToString()}|{item.Description}|\r\n";
            //    result += row;
            //}
            return result;

        }
        /// <summary>
        /// 获取接口描述内容
        /// </summary>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetDescription(string description, string name)
        {
            if (name != description)
            {
                return $"\r\n说明：**{description}**\r\n";
            }
            return string.Empty;
        }
        /// <summary>
        /// 获取构造的导航
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public string GetNavgation(List<SwaggerApiItem> items)
        {
            var result = "<a id='navigation'></a>\r\n# 导航\r\n";

            var navigations = items.GroupBy(i => i.Folder);
            foreach (var navigation in navigations)
            {
                // 分级
                if (!string.IsNullOrEmpty(navigation.Key))
                {
                    result += $"- {navigation.Key}\r\n";
                }
                foreach (var item in navigation)
                {
                    var md5 = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(item.Name));
                    var linkName = BitConverter.ToString(md5).Replace("-", "").ToLower();
                    // 子标题缩进
                    if (!string.IsNullOrEmpty(navigation.Key))
                    {
                        result += $"\t- [{item.Name}](#{linkName})\r\n";
                    }
                    else
                    {
                        result += $"- [{item.Name}](#{linkName})\r\n";

                    }
                }
            }
            return result;
        }
        private string GetTitle(string title)
        {
            return $"# {title}\r\n";
        }
        private string GetInfo(string info)
        {
            return $"**{info}**  \r\n";
        }
        private string GetItemTitle(string title, string operationId)
        {
            var md5 = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(operationId));
            var linkName = BitConverter.ToString(md5).Replace("-", "").ToLower();
            return $"\r\n---\r\n<a id='{linkName}'></a>\r\n### {title}\r\n[返回导航](#navigation)  \r\n";
        }
        private string GetRequestLine(string method, string url)
        {
            return $"**[{method.ToUpperInvariant()}]** `{url}`\r\n";

        }
        /// <summary>
        /// 设置header内容
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        private string GetHeader(List<Header> headers)
        {
            var result = "";
            if (headers.Count > 0)
            {
                result = "#### Header\r\n|键|值|类型|说明|\r\n|-|-|-|-|\r\n";
                //foreach (var item in headers)
                //{
                //    if (Env.TryGetValue(item.Key, out string key))
                //    {
                //        item.Key = key;
                //    }
                //    var row = $"|{item.Key}|{item.Value}|{item.Type}|{item.Key}|\r\n";
                //    result += row;
                //}
            }

            return result;
        }

        /// <summary>
        /// 构造请求内容
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        private string GetParams(IList<Parameter> @params)
        {
            if (@params == null)
            {
                return "";
            }
            string pathContent = "";
            string queryContent = "";
            string bodyContent = "";
            foreach (var param in @params)
            {
                switch (param.@in)
                {
                    case "query":
                        queryContent += $"|{param.name}|{param.@default}|{param.type}|{param.format + param.description}|{param.required}|\r\n";
                        break;
                    case "path":
                        pathContent += $"|{param.name}|{param.@default}|{param.type}|{param.format + param.description}|{param.required}|\r\n";
                        break;
                    case "body":
                        if (param.schema?.@ref != null)
                        {
                            var schemaName = param.schema.@ref.Replace("#/definitions/", "");
                            bodyContent += $"|{param.name}|{param.@default}|[{schemaName}](#{schemaName?.ToLower()})|{param.format + param.description}|{param.required}|\r\n";
                        }
                        else
                        {
                            pathContent += $"|{param.name}|{param.@default}|{param.type}|{param.format + param.description}|{param.required}|\r\n";
                        }
                        break;
                    default:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(pathContent))
            {
                pathContent = "#### 请求路由 \r\n|键(key)|值(value)|类型(type)|说明(description)|必填(required)|\r\n|-|-|-|-|-|\r\n" + pathContent;
            }
            if (!string.IsNullOrEmpty(queryContent))
            {
                pathContent = "#### 请求参数 \r\n|键(key)|值(value)|类型(type)|说明(description)|必填(required)|\r\n|-|-|-|-|-|\r\n" + pathContent;
            }
            if (!string.IsNullOrEmpty(bodyContent))
            {
                pathContent = "#### 请求body \r\n|键(key)|值(value)|类型(type)|说明(description)|必填(required)|\r\n|-|-|-|-|-|\r\n" + pathContent;
            }
            return pathContent + queryContent + bodyContent;
        }

        /// <summary>
        /// 获取定义内容
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetDefinitions()
        {
            string content = "";
            foreach (var definition in Definitions)
            {
                content += $"\r\n<a id='{definition.Key.ToLower()}'>{definition.Key}</a>\r\n";
                var item = definition.Value;
                if (item != null)
                {
                    string propertiesContent = "|键|值|\r\n|-|-|\r\n";
                    // 对象
                    if (item.type == "object")
                    {
                        foreach (var property in item.properties)
                        {
                            // TODO 是否为对象
                            propertiesContent += $"|{property.Key}|{property.Value.type}|\r\n";
                        }
                    }
                    else if (item.type == "integer")
                    {
                        foreach (var obj in item.@enum)
                        {
                            propertiesContent += $"|{obj.ToString()}|{obj.GetType().ToString()}|\r\n";
                        }
                    }
                    // TODO 是否有继承
                    content += propertiesContent;
                }
            }
            return content;
        }

        /// <summary>
        /// 响应内容构造
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string GetResponse(IDictionary<string, Response> responses)
        {
            string content = "#### 响应\r\n";
            foreach (var response in responses)
            {
                var row = $"- 状态码(StatusCode):{response.Key}\r\n";
                row += $"- 返回说明(introcduction):{response.Value.description ?? "无"}\r\n";
                var type = response.Value.schema?.type;
                var @ref = response.Value.schema?.@ref;
                // TODO 循环取
                if (type == "array")
                {
                    @ref = response.Value.schema?.items.@ref;
                }
                var schemaName = @ref;
                if (!String.IsNullOrEmpty(@ref))
                {
                    schemaName = @ref.Replace("#/definitions/", "");
                }
                row += $"- 返回类型(type)：{type}\r\n";
                row += $"- 返回对象(object):[{schemaName ?? "null"}](#{schemaName?.ToLower()})";

                content += row + "\r\n";
            }
            return content;
        }
        #endregion

    }
    public class SwaggerApiItem
    {
        /// <summary>
        /// 文件目录
        /// </summary>
        public string Folder { get; set; }

        public string Name { get; set; }
        public string Method { get; set; }

        public string OperationId { get; set; }

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
        /// 请求
        /// </summary>
        public IList<Parameter> Request { get; set; }
        /// <summary>
        /// 请求query
        /// </summary>
        //public List<Parameter> Query { get; set; }
        /// <summary>
        /// 请求内容
        /// </summary>
        //public string RequestRaw { get; set; }

        public string Description { get; set; }

        public string ResponseJson { get; set; }

        /// <summary>
        /// 响应
        /// </summary>
        public IDictionary<string, Response> Response { get; set; }

    }
}
