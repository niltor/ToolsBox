using System;
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
            var swagger = JsonConvert.DeserializeObject<SwaggerDocument>(content,setting
                );
            Console.ReadLine();
        }
    }
}
