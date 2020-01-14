using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ngApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ngApi
{
    public class JsonToTs
    {

        public JsonToTs()
        {

        }

        public void ParseJson(string jsonStr)
        {
            var job = JObject.Parse(jsonStr);
            foreach (var prop in job.Properties())
            {
                Console.WriteLine(prop.Name);
                Console.WriteLine(prop.Value.ToString());
                Console.WriteLine(prop.Value.Type);
            }
        }

        public void ToNgService(string filePath = "./test.json")
        {
            var jsonFile = new FileInfo(filePath);
            var fileContent = jsonFile.OpenText().ReadToEnd();
            try
            {
                var project = PostManJson.FromJson(fileContent);

                foreach (var service in project.Item)
                {
                    var model = new NgServiceModel
                    {
                        Introduction = service.Name,
                        Methods = service.Children
                    };

                    var serviceContent = model.BuildServiceContent();
                    // 创建服务文件
                }


            }
            catch (Exception e)
            {
                throw;
            }
        }

    }

}
