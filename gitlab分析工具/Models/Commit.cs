using System;
using System.Collections.Generic;
using System.Text;

namespace gitlab分析工具.Models
{
    public class Commit
    {
        public string id { get; set; }
        public string short_id { get; set; }
        public DateTime created_at { get; set; }
        public string[] parent_ids { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string author_name { get; set; }
        public string author_email { get; set; }
        public DateTime authored_date { get; set; }
        public string committer_name { get; set; }
        public string committer_email { get; set; }
        public DateTime committed_date { get; set; }
        public Stats stats { get; set; }
    }
    public class Stats
    {
        public int additions { get; set; }
        public int deletions { get; set; }
        public int total { get; set; }
    }

}
