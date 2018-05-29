using ApiToMD.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;

namespace ApiToMD.Services
{
    public class PostmanService
    {
        public string LocalUrl { get; set; }
        public string ReplaceUrl { get; set; }

        public PostmanService()
        {
            // TODO: 读取相关配置信息
        }

        /// <summary>
        /// 生成md文档
        /// </summary>
        /// <param name="fileStorage">源文件</param>
        /// <param name="outputFileStorage">目标保存文件</param>
        /// <param name="author">作者名</param>
        public async Task<string> ToMarkdownAsync(StorageFile fileStorage, string author = "niltor")
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            author = localSettings.Values["Author"] as string;
            var LocalUrl = localSettings.Values["LocalUrl"] as string;
            var ActualUrl = localSettings.Values["ActualUrl"] as string;

            string result = null;
            var fileContent = await FileIO.ReadTextAsync(fileStorage);
            try
            {
                var model = PostManJson.FromJson(fileContent);
                var api = new ApiModel
                {
                    Name = model.Info.Name,
                    Email = $"{author}@msdev.cc",
                    Author = author,
                    LocalUrl = LocalUrl,
                    ReplaceUrl = ActualUrl
                };
                //设置说明内容
                api.Introduction = @"";
                //设置环境变量
                api.Env = new Dictionary<string, string>
                {
                    { "{{header_token}}", "Access-Token" },
                    { "{{header_uuid}}", "UUID" }
                };
                result = api.ToMarkdown(model.Item);
            }
            catch (Exception e)
            {
                //Console.WriteLine("内容解析出错");
            }
            return result;
        }

        public string ToMarkdown(string fileContent, string author = "niltor")
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            author = localSettings.Values["Author"] as string;
            var LocalUrl = localSettings.Values["LocalUrl"] as string;
            var ActualUrl = localSettings.Values["ActualUrl"] as string;
            string result = null;
            try
            {
                var model = PostManJson.FromJson(fileContent);
                var api = new ApiModel
                {
                    Name = model.Info.Name,
                    Email = $"{author}@msdev.cc",
                    Author = author,
                    LocalUrl = LocalUrl,
                    ReplaceUrl = ActualUrl
                };
                //设置说明内容
                api.Introduction = @"";
                //设置环境变量
                api.Env = new Dictionary<string, string>
                {
                    { "{{header_token}}", "Access-Token" },
                    { "{{header_uuid}}", "UUID" }
                };
                result = api.ToMarkdown(model.Item);
            }
            catch (Exception e)
            {
                //Console.WriteLine("内容解析出错");

                var dialog = new MessageDialog("内容解析出错");
                dialog.ShowAsync();
            }
            return result;
        }
    }
}
