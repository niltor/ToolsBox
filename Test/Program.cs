using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var content = File.ReadAllText("file.json");
            //content = content.Replace("$", "@");

            var setting = new JsonSerializerSettings
            {
                //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore

            };
            var swagger = JsonConvert.DeserializeObject<SwaggerDocument>(content, setting);

            var apiModel = new SwaggerApiModel
            {
                Author = swagger.info.contact?.name,
                Email = swagger.info.contact?.email,
                Introduction = swagger.info.description,
                Name = swagger.info.title,
                Definitions = swagger.definitions
            };

            var items = new List<SwaggerApiItem>();
            // 枚举有效方法
            foreach (var path in swagger.paths)
            {
                var pathItem = ToDictionary(path.Value);
                foreach (var item in pathItem)
                {
                    if (item.Value is Operation value)
                    {
                        var apiItem = new SwaggerApiItem
                        {
                            Folder = path.Key,
                            Method = item.Key,
                            Description = value.description,
                            Name = value.summary,
                            Url = path.Key,
                            RequestBodyType = value.parameters?[0]?.@in,
                            Request = value.parameters,
                            Response = value.responses,
                            OperationId = value.operationId
                        };

                        items.Add(apiItem);
                    }
                    continue;
                }
            }
            var result=apiModel.GetItemsContent(items);
            File.WriteAllText("outputl.md", result);

            Console.ReadLine();
        }

        static Dictionary<string, object> ToDictionary(Object obj)
        {
            var result = new Dictionary<string, object>();
            var fields = obj.GetType().GetFields();

            foreach (var field in fields)
            {
                result.Add(field.Name, field.GetValue(obj));
            }
            return result;
        }

    }
}
