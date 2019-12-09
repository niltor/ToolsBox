using CsvHelper;
using gitlab分析工具.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace gitlab分析工具
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string projectUrl = "/api/v4/projects";
        string commitUrl = "/api/v4/projects/:id/repository/commits?all=true&with_stats=true";
        HttpClient hc = new HttpClient();
        List<Entity.Commit> userCommit = new List<Entity.Commit>();

        public MainWindow()
        {
            InitializeComponent();
            SaveToCsvBtn.IsEnabled = false;
        }

        private async void GetDataBtn_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ServerUrl.Text))
            {
                MessageBox.Show("服务器地址不可为空");
                return;
            }
            if (string.IsNullOrEmpty(PAT.Text))
            {
                MessageBox.Show("需要填写PAT");
                return;
            }
            GetDataBtn.IsEnabled = false;
            // 获取项目
            var projects = await GetProjectsAsync();
            projects = projects.OrderBy(p => p.id).ToList();

            // 获取提交
            foreach (var project in projects)
            {
                var commit = await GetCommits(project);
                // 处理数据格式
                if (commit != null)
                {
                    var currentCommit = commit.Select(s => new Entity.Commit
                    {
                        Additions = s.stats.additions,
                        CreatedTime = s.created_at,
                        Deletions = s.stats.deletions,
                        ProjectName = project.name,
                        Total = s.stats.total,
                        UserName = s.committer_name,

                    }).ToList();
                    userCommit.AddRange(currentCommit);
                    RunMessageTB.Text += "项目" + project.name + "[" + project.id + "] => 共 " + userCommit.Count + "\r\n";
                    RunMessageTB.ScrollToEnd();
                }
            }
            RunMessageTB.Text += "已全部采集完成\r\n";
            RunMessageTB.ScrollToEnd();

            GetDataBtn.IsEnabled = true;
            SaveToCsvBtn.IsEnabled = true;
        }


        /// <summary>
        /// 获取项目信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<Project>> GetProjectsAsync()
        {
            var url = ServerUrl.Text + projectUrl + "?per_page=100";
            hc.DefaultRequestHeaders.TryAddWithoutValidation("PRIVATE-TOKEN", PAT.Text);
            hc.Timeout = TimeSpan.FromSeconds(5);
            var response = await hc.GetStringAsync(url);
            var projects = JsonSerializer.Deserialize<List<Project>>(response);
            return projects;
        }

        /// <summary>
        /// 获取commits
        /// </summary>
        /// <returns></returns>
        public async Task<List<Commit>> GetCommits(Project project)
        {
            var result = new List<Commit>();
            var url = ServerUrl.Text + commitUrl.Replace(":id", project.id.ToString());
            try
            {
                var response = await hc.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    RunMessageTB.Text += "==== 获取commit失败,projectId:" + project.id + "\r\n";
                    return default;
                }
                // 取出分页信息
                var total = response.Headers.Where(h => h.Key == "X-Total")
                    .SingleOrDefault().Value?.FirstOrDefault();
                int pageSize = 100;
                var page = Convert.ToInt32(total) / pageSize + 1;

                for (int i = 1; i <= page; i++)
                {
                    var commits = await GetCommits(project.id, i);
                    result.AddRange(commits);
                }
                return result;
            }
            catch (Exception e)
            {
                RunMessageTB.Text += "==== 获取prject失败,projectId:" + project.id + "\r\n";
                Console.WriteLine(e.Message + e.InnerException);
            }
            return default;
        }

        public async Task<List<Commit>> GetCommits(int projectId, int page = 1, int pageSize = 100)
        {
            var url = ServerUrl.Text + commitUrl.Replace(":id", projectId.ToString());
            var pageUrl = url + "&page=" + page + "&per_page=" + pageSize;

            try
            {
                var _ = await hc.GetStringAsync(pageUrl);
                var commits = JsonSerializer.Deserialize<List<Commit>>(_);
                RunMessageTB.Text += $"获取[{projectId}],page[{page}] \r\n";
                return commits;
            }
            catch (Exception)
            {
                // TODO:存储未成功的内容，等待重试
                RunMessageTB.Text += "==== PID:" + projectId + ";page=" + page + "\r\n";
                File.AppendAllText("retry.txt", projectId + ";" + page + "\r\n");
            }
            Thread.Sleep(80);
            return default;
        }

        private void SaveToCsvBtn_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog
            {
                DefaultExt = ".csv",
                Filter = "csv file(*.csv)|*.csv",
                FileName = "data"
            };

            if (dlg.ShowDialog() == true)
            {
                SaveToCsvBtn.IsEnabled = false;
                // 保存数据
                using (var writer = new StreamWriter(dlg.FileName))
                {
                    using (var csv = new CsvWriter(writer))
                    {
                        csv.WriteRecords(userCommit);
                    }
                }
                MessageBox.Show("保存成功");
                SaveToCsvBtn.IsEnabled = true;
            }
        }
    }
}
