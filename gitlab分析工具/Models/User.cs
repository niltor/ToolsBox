using System;
using System.Collections.Generic;
using System.Text;

namespace gitlab分析工具.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string state { get; set; }
        public string avatar_url { get; set; }
        public string web_url { get; set; }
        public DateTime created_at { get; set; }
        public object bio { get; set; }
        public object location { get; set; }
        public string public_email { get; set; }
        public string skype { get; set; }
        public string linkedin { get; set; }
        public string twitter { get; set; }
        public string website_url { get; set; }
        public object organization { get; set; }
        public DateTime last_sign_in_at { get; set; }
        public DateTime confirmed_at { get; set; }
        public string last_activity_on { get; set; }
        public string email { get; set; }
        public int theme_id { get; set; }
        public int color_scheme_id { get; set; }
        public int projects_limit { get; set; }
        public DateTime current_sign_in_at { get; set; }
        public object[] identities { get; set; }
        public bool can_create_group { get; set; }
        public bool can_create_project { get; set; }
        public bool two_factor_enabled { get; set; }
        public bool external { get; set; }
        public object private_profile { get; set; }
        public bool is_admin { get; set; }
    }

}
