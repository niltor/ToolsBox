using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ApiToMD.Models
{

    public partial class PostManJson
    {
        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("item")]
        public List<Item> Item { get; set; }
    }

    public partial class Info
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("_postman_id")]
        public string PostmanId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("schema")]
        public string Schema { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("request")]
        public Request Request { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("response")]
        public List<Response> Response { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("item")]
        public List<Item> Children { get; set; }
    }

    public partial class Request
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("header")]
        public List<Header> Header { get; set; }

        [JsonProperty("url")]
        public Url Url { get; set; }
    }

    public partial class Body
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("urlencoded")]
        public List<Params> Urlencoded { get; set; }

        [JsonProperty("formdata")]
        public List<Params> Formdata { get; set; }

        [JsonProperty("raw")]
        public string Raw { get; set; }
    }

    public partial class Params
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class Header
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class Url
    {
        [JsonProperty("path")]
        public List<string> Path { get; set; }

        [JsonProperty("query")]
        public List<Query> Query { get; set; }

        [JsonProperty("host")]
        public List<string> Host { get; set; }

        [JsonProperty("protocol")]
        public string Protocol { get; set; }

        [JsonProperty("raw")]
        public string Raw { get; set; }
    }

    public partial class Query
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("equals")]
        public bool Equals { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class Response
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("_postman_previewtype")]
        public string PostmanPreviewtype { get; set; }

        [JsonProperty("_postman_previewlanguage")]
        public string PostmanPreviewlanguage { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("header")]
        public List<Params> Header { get; set; }

        [JsonProperty("cookie")]
        public List<Cookie> Cookie { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("responseTime")]
        public long ResponseTime { get; set; }

        [JsonProperty("originalRequest")]
        public OriginalRequest OriginalRequest { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Cookie
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("expires")]
        public string Expires { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("httpOnly")]
        public bool HttpOnly { get; set; }

        [JsonProperty("secure")]
        public bool Secure { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class OriginalRequest
    {
        [JsonProperty("header")]
        public List<Header> Header { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("url")]
        public Url Url { get; set; }
    }


    public class Result
    {

        [JsonProperty("data")]
        public string Data { get; set; }
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("msg")]
        public string Msg { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public partial class PostManJson
    {
        public static PostManJson FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PostManJson>(json, Converter.Settings);
        }
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }


}
