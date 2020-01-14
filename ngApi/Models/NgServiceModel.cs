using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ngApi.Models
{
    /// <summary>
    /// ng服务模型
    /// </summary>
    class NgServiceModel
    {
        /// <summary>
        /// 说明
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 接口方法
        /// </summary>
        public List<Item> Methods { get; set; }

        public NgServiceModel()
        {
        }

        public string getServiceName()
        {
            if (Methods.Count < 1) return default;
            // 获取serviceName
            var path = Methods.First().Request.Url?.Path;
            var serviceName = path[1];
            return serviceName.First().ToString().ToUpper() + serviceName.Substring(1);
        }

        /// <summary>
        /// 一组接口内容
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public string BuildServiceContent()
        {
            if (Methods.Count < 1) return default;
            string functionContent = "";
            foreach (var item in Methods)
            {
                var requestMethod = new RequestMethodModel
                {
                    Description = item.Name,
                    Method = item.Request.Method,
                    Query = item.Request.Url.Query,
                    RequestBodyType = item.Request.Body?.Mode,
                    ResponseJson = item.Response?.FirstOrDefault()?.Body,
                    Path = item.Request.Url.Path
                };
                //不同请求类型
                switch (requestMethod.RequestBodyType)
                {
                    case "formdata":
                        requestMethod.Params = item.Request.Body.Formdata;
                        break;
                    case "raw":
                        requestMethod.RequestRaw = item.Request.Body.Raw;
                        break;
                    default:
                        requestMethod.Params = item.Request.Body.Urlencoded;
                        break;
                }
                functionContent += requestMethod.ToString();
            }
            string comments = @$"/**
  * {Introduction}
  */";
            string content = $@"import {{ Injectable }} from '@angular/core';
import {{ BaseService }} from './base.service';
import {{ HttpClient }} from '@angular/common/http';
import {{ Observable }} from 'rxjs';

@Injectable({{
  providedIn: 'root'
}})
{comments}
export class {getServiceName()}Service extends BaseService {{
  constructor(http: HttpClient) {{
    super(http);
  }}

{functionContent}
}}
";
            return content;
        }
    }

    /// <summary>
    /// 请求方法模型
    /// </summary>
    public class RequestMethodModel
    {
        public string Method { get; set; }
        public List<string> Path { get; set; }
        /// <summary>
        /// 请求类型
        /// </summary>
        public string RequestBodyType { get; set; }
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
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 返回的json示例
        /// </summary>
        public string ResponseJson { get; set; }

        public List<Params> ResponseFileds { get; set; }



        public override string ToString()
        {
            string functionStr;
            if (Method.ToLower() == "get")
            {
                functionStr = GetGetFunction();
            }
            else
            {
                functionStr = GetPostFunction();
            }

            return GetComments() + functionStr;
        }
        /// <summary>
        /// 获取get请求函数
        /// </summary>
        /// <returns></returns>
        private string GetGetFunction()
        {
            var name = Path.Last();
            var query = Query?.Select(s => s.Key + ": string").ToList();

            var functionParams = query == null ? "" : string.Join(",", query);
            query = Query?.Select(s => s.Key + $"=${{{s.Key.Trim()}}}").ToList();
            var queryString = query == null ? "" : string.Join("&", query);
            if (!string.IsNullOrEmpty(queryString))
            {
                queryString = @$" + `{queryString}`";
            }
            var routePath = "";
            foreach (var item in Path)
            {
                routePath += "/" + item;
            }

            var typeName = name + "VM";
            var function = @$"{name}({functionParams}): Observable<{typeName}>{{
  const url='{routePath}?'{queryString};
  return this.get<{typeName}>(url);
}}
";
            return function;
        }
        /// <summary>
        /// 获取post请求函数
        /// </summary>
        /// <returns></returns>
        private string GetPostFunction()
        {
            var name = Path.Last();
            var query = Query?.Select(s => s.Key + ": string").ToList();
            var functionParams = query == null ? "" : string.Join(",", query);
            if (!string.IsNullOrEmpty(functionParams))
            {
                functionParams += ", ";
            }

            query = Query?.Select(s => s.Key + $"={{{s.Key}}}").ToList();
            var queryString = query == null ? "" : string.Join("&", query);
            if (!string.IsNullOrEmpty(queryString))
            {
                queryString = @$" + `{queryString}`";
            }

            var routePath = "";
            foreach (var item in Path)
            {
                routePath += "/" + item;
            }

            var dataType = name + "Form";
            var typeName = name + "VM";

            var function = @$"{name}({functionParams}data: {dataType}): Observable<{typeName}>{{
  const url='{routePath}?'{queryString};
  return this.post<{typeName}>(url, data);
}}
";
            return function;
        }
        /// <summary>
        /// 获取接口注释
        /// </summary>
        /// <returns></returns>
        private string GetComments()
        {
            var commentsParams = "";
            if (Query != null)
            {
                foreach (var item in Query)
                {
                    commentsParams += $" * @param {item.Key} {item.Description}\r\n";
                }
                commentsParams = "\r\n" + commentsParams;

            }
            // 如果是Post请求
            var data = "";
            if (RequestBodyType != null)
            {
                var name = Path.Last();
                data = $"\r\n * {name}Form 提交数据\r\n";
            }
            var comments = @$"/**
 * {Description}{commentsParams}{data} */
";
            return comments;
        }
    }

}
