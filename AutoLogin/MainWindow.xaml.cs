﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }

        readonly string baseUrl = "http://10.0.9.156/user-login-auth";
        Configuration configuration;

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            InitializeComponent();
            GetConfig();
            GetLocalInfo();
        }

        /// <summary>
        /// 获取默认配置
        /// </summary>
        public void GetConfig()
        {
            UsernameBox.Text = configuration.AppSettings.Settings["username"]?.Value;
            PasswordBox.Password = configuration.AppSettings.Settings["password"]?.Value;
            if (string.IsNullOrEmpty(UsernameBox.Text))
            {
                configuration.AppSettings.Settings.Add("username", "");
            }
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                configuration.AppSettings.Settings.Add("password", "");
            }
            configuration.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection(configuration.AppSettings.SectionInformation.Name);
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameBox.Text;
            var password = PasswordBox.Password;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("用户名或密码不可为空");
            }

            LoginBtn.Content = "正在登录";
            LoginBtn.IsEnabled = false;
            using (var hc = new HttpClient())
            {
                var url = baseUrl + "?id=0&user=" + IpAddress + "&mac=" + MacAddress;
                var data = new List<KeyValuePair<string, string>>();
                data.Add(new KeyValuePair<string, string>("param[UserName]", username));
                data.Add(new KeyValuePair<string, string>("param[UserPswd]", password));
                var httpContent = new FormUrlEncodedContent(data);
                var response = await hc.PostAsync(url, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var json = JsonSerializer.Deserialize<LoginResponseModel>(responseString);
                    if (json.status == "0")
                    {
                        MessageBox.Show(json.msg);
                        LoginBtn.IsEnabled = true;
                    }
                    else
                    {
                        // 登录成功
                        configuration.AppSettings.Settings["username"].Value = username;
                        configuration.AppSettings.Settings["password"].Value = password;
                        configuration.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection(configuration.AppSettings.SectionInformation.Name);
                        LoginBtn.Content = "登录成功，程序将自动退出";

                        var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                        dispatcherTimer.Tick += new EventHandler(Exit);
                        dispatcherTimer.Interval = new TimeSpan(0, 0, 2, 500);
                        dispatcherTimer.Start();
                    }
                }
                else
                {
                    LoginBtn.IsEnabled = true;
                }
            }
        }

        public void Exit(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// 获取本地ip及mac信息
        /// </summary>
        public void GetLocalInfo()
        {
            var query = NetworkInterface.GetAllNetworkInterfaces()
               .Where(n =>
                   n.OperationalStatus == OperationalStatus.Up &&
                   n.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                   n.GetIPProperties().DnsAddresses.Any(da => da.ToString() == "10.0.9.1")
                   )
               .Select(_ => new
               {
                   PhysicalAddress = _.GetPhysicalAddress(),
                   IPProperties = _.GetIPProperties(),
               }).FirstOrDefault();

            var ua = query.IPProperties.UnicastAddresses.Where(ua => ua.IsDnsEligible == true).FirstOrDefault();
            IpAddress = ua.Address.ToString();
            MacAddress = string.Join(":", query.PhysicalAddress.GetAddressBytes().Select(b => b.ToString("x2")));
            Info.Text = "IP:" + IpAddress + "\nMac:" + MacAddress;

        }
 

    }
}
