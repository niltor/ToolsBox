using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PostmanToMD.Models
{
    /// <summary>
    /// Api模型
    /// </summary>
    class ApiModel
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
        public List<Items> Items { get; set; }

        public Dictionary<string, string> Env { get; set; }

        public void WriteToMarkdown(string path)
        {
            var content = "";
            content = GetTitle(Name) + GetInfo("Author:" + Author) + GetInfo("Email:" + Email) + Introduction + Common
                + GetNavgation(Items);

            foreach (var item in Items)
            {
                content += GetItemTitle(item.Name)
                    + GetRequestLine(item.Method, item.Url) + GetHeader(item.Header)
                    + GetParams(item.Params) + GetResponseJson(item.ResponseJson);
            }

            var file = new FileInfo(path);
            using (var writer = file.CreateText())
            {
                writer.Write(content);
            }
        }

        public string GetNavgation(List<Items> items)
        {
            var result = "<a id='navigation'></a>\r\n# 导航\r\n";
            foreach (var item in items)
            {
                var md5 = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(item.Name));
                var linkName = BitConverter.ToString(md5).Replace("-", "").ToLower();
                result += $"- [{item.Name}](#{linkName})\r\n";
            }
            return result;
        }


        public string GetTitle(string title)
        {
            return $"# {title}\r\n";
        }
        public string GetInfo(string info)
        {
            return $"**{info}**  \r\n";
        }
        public string GetItemTitle(string title)
        {
            var md5 = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(title));
            var linkName = BitConverter.ToString(md5).Replace("-", "").ToLower();
            return $"\r\n---\r\n<a id='{linkName}'></a>\r\n### {title}\r\n[返回导航](#navigation)  \r\n";


        }
        public string GetRequestLine(string method, string url)
        {
            return $"**[{method}]** `{url}`\r\n";

        }
        /// <summary>
        /// 设置header内容
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        public string GetHeader(List<Header> headers)
        {
            var result = "#### Header\r\n|键|值|类型|说明|\r\n|-|-|-|-|\r\n";
            foreach (var item in headers)
            {
                if (Env.TryGetValue(item.Key, out string key))
                {
                    item.Key = key;
                }
                var row = $"|{item.Key}|{item.Value}|{item.Type}|{item.Key}|\r\n";
                result += row;
            }
            return result;
        }
        public string GetParams(List<Params> @params)
        {
            if (@params == null)
                return "";
            var result = "#### 请求参数\r\n|键|值|类型|说明|\r\n|-|-|-|-|\r\n";
            foreach (var item in @params)
            {
                var row = $"|{item.Key}|{item.Value}|{item.Type}|{item.Description}|\r\n";
                result += row;
            }
            return result;
        }

        public string GetResponseJson(string json)
        {
            var result = "#### 返回字符串\r\n";
            result += "```json\r\n";
            if (!string.IsNullOrEmpty(json))
            {
                var obj = JsonConvert.DeserializeObject(json);
                result += JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            result += "\r\n```\r\n";

            return result;
        }

    }
    public class Items
    {
        public string Name { get; set; }
        public string Method { get; set; }

        public string Url { get; set; }

        public string RequestBodyType { get; set; }

        public List<Header> Header { get; set; }

        public List<Params> Params { get; set; }

        public string Description { get; set; }

        public string ResponseJson { get; set; }

        public List<Params> ResponseFileds { get; set; }

    }



}
