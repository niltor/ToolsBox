using System;
using System.Diagnostics;
using System.Net.Http;

namespace Test
{
    public class RequestTimer
    {
        string baseUrl = "http://cims.local/admin/data/FullToEsAsync";

        public async System.Threading.Tasks.Task RunAsync(int from = 0, int setup = 5000)
        {
            using (var hc = new HttpClient())
            {
                var timer = new Stopwatch();
                timer.Start();
                while (timer.Elapsed.TotalMinutes < 60)
                {
                    try
                    {
                        string url = baseUrl + $"?from={from}&number={setup}";
                        Console.WriteLine("开始处理" + from + "到" + (from + setup));
                        var response = await hc.GetStringAsync(url);
                        if (response.Contains("end"))
                        {
                            Console.WriteLine("全部执行结束");
                            return;
                        }
                        if (response.Contains("ok"))
                        {
                            Console.WriteLine("成功执行:" + from + "=>" + (from + setup));
                        }
                        from = from + setup;
                        Console.WriteLine("已耗时:" + timer.Elapsed.TotalSeconds + "秒");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("出错 :" + from + "+" + setup);
                        timer.Stop();
                        throw;
                    }
                }
                timer.Stop();


            }
        }

    }
}
