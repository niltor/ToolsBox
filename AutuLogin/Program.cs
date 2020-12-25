using System;
using System.Net.Http;

namespace AutuLogin
{
    class Program
    {


        static void Main(string[] args)
        {

            var login = new Login();
            if (login.GetLocalInfo())
            {
                Console.WriteLine("请输入用户名，按回车确认");
                var username = Console.ReadLine();
                Console.WriteLine("请输入密码，按回车确认");
                var password = Console.ReadLine();
                login.DoLoginAsync(username, password);
            }
            else
            {
                Console.WriteLine("请连接到正确的网络再尝试登录");
            }

            Console.WriteLine("");

        }

    }
}
