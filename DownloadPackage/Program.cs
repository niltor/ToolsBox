using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DownloadPackage
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string ipRex = "10.0.9.";
            var tasks = new List<Task>();

            for (int i = 1; i < 255; i++)
            {
                string ip = ipRex + i;
                TestWebAsync(ip);
            }

            Task.WaitAll(tasks.ToArray());
            System.Console.WriteLine("finish");
            Console.ReadLine();
        }

        static async Task TestWebAsync(string ip)
        {
            try
            {
                using (var hc = new HttpClient())
                {
                    var response = await hc.GetAsync("http://" + ip);
                    if (response.IsSuccessStatusCode)
                    {
                        System.Console.WriteLine(ip);
                        string result = await response.Content?.ReadAsStringAsync();
                        if (result.Contains("CIMS"))
                        {
                            System.Console.WriteLine("find:" + ip);
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                // System.Console.WriteLine(e.Message);
            }
        }
        static void DownloadPackage()
        {
            Console.WriteLine("start");
            string url1 = "https://az320820.vo.msecnd.net/packages/msdev.pddopensdk.aspnetcore.0.1.1.nupkg";
            string url2 = "https://az320820.vo.msecnd.net/packages/msdev.pddopensdk.0.1.1.nupkg";
            var rdm = new Random();
            int total = 1;

            while (true && total < 1000)
            {
                var num = rdm.Next(10, 60);
                var sleepTime = TimeSpan.FromSeconds(num);
                Download(url2);
                Download(url1);
                Console.WriteLine("下载" + total);
                total++;
                System.Console.WriteLine("waiting...." + sleepTime);
                Thread.Sleep((int)sleepTime.TotalMilliseconds);
            }
        }
        static void Download(string url)
        {
            using (var wc = new WebClient())
            {
                wc.DownloadFile(url, "temp1");
                File.Delete("temp1");
                Console.WriteLine("download:" + url);
            }
        }
    }
}
