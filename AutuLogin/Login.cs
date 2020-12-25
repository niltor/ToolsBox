using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutuLogin
{
    public class Login
    {

        readonly string baseUrl = "http://10.0.9.156/user-login-auth";
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }

        public void DoLoginAsync(string username, string password)
        {
            using (var hc = new HttpClient())
            {
                var url = baseUrl + "?id=0&user=" + IpAddress + "&mac=" + MacAddress;
                var data = new List<KeyValuePair<string, string>>();
                data.Add(new KeyValuePair<string, string>("param[UserName]", username));
                data.Add(new KeyValuePair<string, string>("param[UserPswd]", password));
                var httpContent = new FormUrlEncodedContent(data);
                var response = hc.PostAsync(url, httpContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    var json = JsonConvert.DeserializeObject<LoginResponseModel>(responseString);
                    if (json.status == "0")
                    {
                        Console.WriteLine(json.msg);
                    }
                    else
                    {
                        // 登录成功
                        Console.WriteLine("登录成功，程序将自动退出");
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        /// <summary>
        /// 获取本地ip及mac信息
        /// </summary>
        public bool GetLocalInfo()
        {
            var query = NetworkInterface.GetAllNetworkInterfaces()
               .Where(n =>
                   n.OperationalStatus == OperationalStatus.Up &&
                   n.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                   n.GetIPProperties().DhcpServerAddresses.Any(dhcp => dhcp.ToString() == "10.0.9.1")
                   )
               .Select(_ => new
               {
                   PhysicalAddress = _.GetPhysicalAddress(),
                   IPProperties = _.GetIPProperties(),
               }).FirstOrDefault();

            if (query == null)
            {
                Console.WriteLine("没有有效的网络连接，请检查您的网络连接！");
                return false;
            }
            else
            {
                var ua = query.IPProperties.UnicastAddresses.Where(_ => _.IsDnsEligible == true).FirstOrDefault();
                IpAddress = ua.Address.ToString();
                MacAddress = string.Join(":", query.PhysicalAddress.GetAddressBytes().Select(b => b.ToString("x2")));
                Console.WriteLine(IpAddress + MacAddress);
                return true;
            }
        }
    }
}
