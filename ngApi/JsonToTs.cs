﻿using Newtonsoft.Json.Linq;
using ngApi.Models;
using System;
using System.IO;

namespace ngApi
{
    public class JsonToTs
    {

        public JsonToTs()
        {

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
                    Console.WriteLine(serviceContent);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }

}
