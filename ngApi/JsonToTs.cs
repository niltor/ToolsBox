using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ngApi
{
    public class JsonToTs
    {

        readonly Person person;
        public JsonToTs()
        {
            person = new Person
            {
                Name = "chris",
                Age = 18,
            };

            var skills = new List<Skill>();
            skills.Add(new Skill { Name = "math", Level = "Top" });
            skills.Add(new Skill { Name = "language", Level = "Middle" });
            skills.Add(new Skill { Name = "english", Level = "Bottom" });
            person.Skills = skills;
        }

        public void ParseJson()
        {
            var jsonStr = JsonConvert.SerializeObject(person);

            var job = JObject.Parse(jsonStr);
            foreach (var prop in job.Properties())
            {
                Console.WriteLine(prop.Name);
                Console.WriteLine(prop.Value.ToString());
                Console.WriteLine(prop.Value.Type);
            }
        }
    }


    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Skill> Skills { get; set; }
    }

    public class Skill
    {
        public string Name { get; set; }
        public string Level { get; set; }
    }
}
