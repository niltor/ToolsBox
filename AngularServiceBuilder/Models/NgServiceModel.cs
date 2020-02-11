using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AngularServiceBuilder.Models
{
    /// <summary>
    /// ng服务模型
    /// </summary>
    public class NgServiceModel
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

        public string GetServiceName()
        {
            if (Methods.Count < 1) return default;
            // 获取serviceName
            var path = Methods.First().Request.Url?.Path;
            var serviceName = path[1];
            return ToTitle(serviceName);
        }

        public string ToTitle(string str)
        {
            return str.First().ToString().ToUpper() + str.Substring(1);
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
            string modelsContent = "";
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
                if (requestMethod.Path == null) continue;
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
                        requestMethod.Params = item.Request.Body?.Urlencoded;
                        break;
                }
                functionContent += requestMethod.ToString();
                modelsContent += requestMethod.BuildTsInterface();
            }
            string comments = @$"/**
 * {Introduction}
 */";
            string content = $@"import {{ Injectable, Inject }} from '@angular/core';
import {{ BaseService, API_BASE_URL, Result }} from './base.service';
import {{ HttpClient }} from '@angular/common/http';
import {{ Observable }} from 'rxjs';

@Injectable({{
  providedIn: 'root'
}})
{comments}
export class {GetServiceName()}Service extends BaseService {{
  constructor(http: HttpClient, @Inject(API_BASE_URL) baseUrl?: string) {{
    super(http, baseUrl);
  }}

{functionContent}
}}
";
            content += modelsContent;
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

        /// <summary>
        /// 生成ts对应的接口
        /// </summary>
        /// <returns></returns>
        public string BuildTsInterface()
        {
            string modelContent = "";
            string name = Path.Last();
            name = name.Replace("_", "");
            name = name.First().ToString().ToUpper() + name.Substring(1);
            // 返回的模型构建
            if (!string.IsNullOrEmpty(ResponseJson))
            {
                Console.WriteLine(ResponseJson);
                var response = JObject.Parse(ResponseJson);
                if (response["data"].HasValues)
                {
                    modelContent += ParseJson(response["data"], name + "VM");
                }
            }
            // 请求的模型
            if (Params != null && Params.Count > 0)
            {
                modelContent += ParamsToTs(name + "Form");
            }

            if (!string.IsNullOrEmpty(RequestRaw))
            {
                var request = JObject.Parse(RequestRaw);
                modelContent += ParseJson(request, name + "Form");
            }
            return modelContent;
        }

        public override string ToString()
        {
            string functionStr;
            string requestMethod = Method.ToLower();
            if (requestMethod == "get" || requestMethod == "delete")
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
            name = name.Replace("_", "");
            name = name.First().ToString().ToUpper() + name.Substring(1);
            var query = Query?.Select(s => s.Key.Replace("[", "").Replace("]", "") + ": string").ToList();

            var functionParams = query == null ? "" : string.Join(",", query);
            query = Query?.Select(s => s.Key.Replace("[", "").Replace("]", "") +
                $"=${{{s.Key.Replace("[", "").Replace("]", "").Trim()}}}")
                .ToList();
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
            // 判断是否有返回的示例
            if (ResponseJson != null)
            {
                var response = JObject.Parse(ResponseJson);
                var data = response["data"];
                if (!data.HasValues)
                {
                    typeName = "string";
                }
                else if (data.Type == JTokenType.Array)
                {
                    typeName = name + "VM[]";
                }
            }
            else
            {
                typeName = "void";
            }
            string prefix = Method.ToLower();
            var function = @$"{ToTitle(prefix) + name}({functionParams}): Observable<Result<{typeName}>>{{
  const url='{routePath}?'{queryString};
  return this.{prefix}<Result<{typeName}>>(url);
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
            var prefix = Method.ToLower();
            var name = Path.Last();
            name = name.Replace("_", "");
            name = name.First().ToString().ToUpper() + name.Substring(1);
            var query = Query?.Select(s => s.Key.Replace("[", "").Replace("]", "") + ": string").ToList();
            var functionParams = query == null ? "" : string.Join(",", query);

            query = Query?.Select(s => s.Key.Replace("[", "").Replace("]", "") +
                $"=${{{s.Key.Replace("[", "").Replace("]", "").Trim()}}}")
                .ToList();
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
            string dataType = "";
            string hasData = "";


            if (Params == null && string.IsNullOrEmpty(RequestRaw))
            {
                dataType = "";
            }
            else
            {
                dataType = "data: " + name + "Form";
                hasData = ", data";
                if (!string.IsNullOrEmpty(functionParams))
                {
                    dataType = ", " + dataType;
                }
            }
            var typeName = name + "VM";
            // 判断是否有返回的示例
            if (ResponseJson != null)
            {
                var response = JObject.Parse(ResponseJson);
                var data = response["data"];
                if (!data.HasValues)
                {
                    typeName = "string";
                }
            }
            else
            {
                typeName = "void";
            }
            var function = @$"{ToTitle(prefix) + name}({functionParams}{dataType}): Observable<Result<{typeName}>>{{
  const url='{routePath}?'{queryString};
  return this.{prefix}<Result<{typeName}>>(url{hasData});
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
                    item.Description ??= "无说明";
                    commentsParams += $" * @param {item.Key} {item.Description}\r\n";
                }
            }
            // 如果是Post请求
            var data = "";
            if (RequestBodyType != null)
            {
                var name = Path.Last();
                name = name.Replace("_", "");
                data = $" * @param {name}Form 提交数据\r\n";
            }
            var comments = @$"
/**
 * {Description}
{commentsParams}{data} */
";
            return comments;
        }

        public string ParseJson(JToken data, string name)
        {
            string propertyString = "";
            string innerContent = "";
            if (data != null && data.HasValues)
            {
                if (data.Type == JTokenType.Array)
                {
                    data = ((JArray)data).First;
                    innerContent += ParseJson(data, name);
                }
                else if (data.Type != JTokenType.Object)
                {
                    return "";
                }
                foreach (var prop in ((JObject)data).Properties())
                {
                    string valueType = "";
                    switch (prop.Value.Type)
                    {
                        case JTokenType.Object:
                            valueType = $"{ToTitle(prop.Name)}VM";
                            innerContent += ParseJson((JObject)prop.Value, $"{ToTitle(prop.Name)}VM");
                            break;
                        case JTokenType.Array:
                            var value = prop.Value?.First;
                            valueType = GetType(value) + "[]";
                            if (value != null && value.Type == JTokenType.Object)
                            {
                                valueType = $"{ToTitle(prop.Name)}VM[]";
                                innerContent += ParseJson((JObject)value, $"{ToTitle(prop.Name)}VM");
                            }
                            break;
                        case JTokenType.Integer:
                        case JTokenType.Bytes:
                        case JTokenType.Float:
                            valueType = "number";
                            break;
                        case JTokenType.Boolean:
                            valueType = "boolean";
                            break;
                        case JTokenType.Null:
                            valueType = "null";
                            break;
                        case JTokenType.Undefined:
                            break;
                        case JTokenType.Date:
                        case JTokenType.TimeSpan:
                            valueType = "Date";
                            break;
                        default:
                            valueType = "string";
                            break;
                    }
                    propertyString += $"{prop.Name}: {valueType};\r\n";
                }
            }

            string interfaceString = @$"export interface {name} {{
  {propertyString}
}}
{innerContent}
";

            return interfaceString;
        }
        public string GetType(JToken data)
        {
            string valueType = "";
            switch (data.Type)
            {
                case JTokenType.Integer:
                case JTokenType.Bytes:
                case JTokenType.Float:
                    valueType = "number";
                    break;
                case JTokenType.Boolean:
                    valueType = "boolean";
                    break;
                case JTokenType.Null:
                    valueType = "null";
                    break;
                case JTokenType.Undefined:
                    break;
                case JTokenType.Date:
                case JTokenType.TimeSpan:
                    valueType = "Date";
                    break;
                default:
                    valueType = "string";
                    break;
            }
            return valueType;
        }

        /// <summary>
        /// 请求参数变为ts接口
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string ParamsToTs(string name)
        {
            string propertyString = "";
            foreach (var item in Params)
            {
                var comment = @$"/**
 * {item.Description ?? "无说明"}
 */
";
                propertyString += comment + $"{item.Key}: string;\r\n";
            }

            string interfaceString = @$"export interface {name} {{
{propertyString}
}}
";

            return interfaceString;
        }

        public string ToTitle(string str)
        {
            return str.First().ToString().ToUpper() + str.Substring(1);
        }
    }

}
