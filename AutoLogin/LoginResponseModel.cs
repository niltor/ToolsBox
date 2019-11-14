using System;
using System.Collections.Generic;
using System.Text;

namespace AutoLogin
{
    public class LoginResponseModel
    {
        public string status { get; set; }
        public string msg { get; set; }
        public string redirect { get; set; }
        public string user_name { get; set; }
    }

}
