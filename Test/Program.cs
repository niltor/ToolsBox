using System;
using System.IO;
using System.Net;
using System.Text;

namespace Test
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //var timer = new RequestTimer();
            //await timer.RunAsync(0,3000);

            Test();
            Console.WriteLine("finish");

        }

        static void Download()
        {
            var urls = File.ReadAllLines("urls.txt");
            Console.WriteLine("total:" + urls.Length);
            int i = 0;
            using (var wc = new WebClient())
            {
                foreach (var url in urls)
                {
                    // 文件名
                    var fileName = url.Substring(url.LastIndexOf("/") + 1);
                    // 目录名
                    var path = url.Replace("https://img.cissdata.com/", "");
                    path = path.Substring(0, path.LastIndexOf("/"));
                    path = path.Replace("/", "\\");
                    Console.WriteLine(fileName);
                    Console.WriteLine(path);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    wc.DownloadFile(url, Path.Combine(path, fileName));
                    Console.WriteLine("done:" + ++i);
                }
            }
        }

        static void Test()
        {
            byte[] bytes = Encoding.UTF8.GetBytes("我");
            var myString = Encoding.ASCII.GetString(bytes);

            foreach (var item in bytes)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(myString);
        }

    }
}
