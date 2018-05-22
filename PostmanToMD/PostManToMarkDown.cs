using Newtonsoft.Json;
using PostmanToMD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostmanToMD
{
    public class PostManToMarkDown
    {
        readonly string devDaemon = "cisscool.app";
        readonly string testDaemon = "cetc.cisscool.com";
        //static string onlineDaemon = "cetc.cisscool.com";

        public PostManToMarkDown(string localUrl, string devUrl)
        {
            devDaemon = localUrl;
            testDaemon = devUrl;
        }

        /// <summary>
        /// 生成md文档
        /// </summary>
        /// <param name="filePath">源文件</param>
        /// <param name="outputPath">目标保存文件</param>
        /// <param name="author">作者名</param>
        public void Run(string filePath, string outputPath, string author = "CIMS")
        {
            var jsonFile = new FileInfo(filePath);
            var fileContent = jsonFile.OpenText().ReadToEnd();

            try
            {
                var model = PostManJson.FromJson(fileContent);
                var api = new ApiModel
                {
                    Name = model.Info.Name,
                    Email = $"{author}@cissdata.com",
                    Author = author
                };

                var items = model.Item.Select(m =>
                {
                    var item = new Items
                    {
                        Name = m.Name,
                        Description = m.Request.Description,
                        Header = m.Request.Header,
                        Method = m.Request.Method,
                        Query = m.Request.Url.Query,
                        RequestBodyType = m.Request.Body?.Mode,
                        ResponseJson = m.Response?.FirstOrDefault()?.Body,
                        //替换原测试地址
                        Url = m.Request.Url.Raw.Replace(devDaemon, testDaemon)
                    };

                    //不同请求类型
                    switch (item.RequestBodyType)
                    {
                        case "formdata":
                            item.Params = m.Request.Body.Formdata;
                            break;
                        case "raw":
                            item.RequestRaw = m.Request.Body.Raw;
                            break;
                        default:
                            item.Params = m.Request.Body.Urlencoded;
                            break;
                    }
                    return item;
                }).ToList();
                api.Items = items;

                //设置返回对象
                var successResult = new Result
                {
                    Data = "",
                    ErrorCode = 0,
                    Status = 1,
                    Count = 1,
                    Msg = ""
                };
                var errorResult = new Result
                {
                    Data = "",
                    ErrorCode = 1,
                    Status = 0,
                    Count = 0,
                    Msg = ""

                };
                //设置说明内容
                api.Introduction = @"";
                //设置环境变量
                api.Env = new Dictionary<string, string>
                {
                    { "{{header_token}}", "Access-Token" },
                    { "{{header_uuid}}", "UUID" }
                };
                //            api.Common = @"成功返回:
                //```json
                //" + JsonConvert.SerializeObject(successResult, Formatting.Indented) + @"
                //```
                //";
                //            api.Common += @"失败返回:
                //```json
                //" + JsonConvert.SerializeObject(errorResult, Formatting.Indented) + @"
                //```
                //";
                api.WriteToMarkdown(outputPath);
            }
            catch (Exception e)
            {
                MessageBox.Show("内容解析出错:" + e.Message);
            }
        }
    }
}
