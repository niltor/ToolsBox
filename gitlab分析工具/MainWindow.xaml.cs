using gitlab分析工具.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gitlab分析工具
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string projectUrl = "/api/v4/projects";
        string commitUrl = "/api/v4/projects/:id/repository/commits?all=true&with_stats=true";
        string commitDetailUrl = "/api/v4/projects/:id/repository/commits/:sha";
        HttpClient hc = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
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

            // 获取提交
            var userCommit = new List<Entity.Commit>();
            foreach (var project in projects)
            {
                var commit = await GetCommits(project);
                // 处理数据格式
                var currentCommit = commit.Select(s => new Entity.Commit
                {
                    Additions = s.stats.additions,
                    CreatedTime = s.created_at,
                    Deletions = s.stats.deletions,
                    ProjectName = project.name,
                    Total= s.stats.total,
                    UserName= s.committer_name,

                }).ToList();
                userCommit.AddRange(currentCommit);
                RunMessageTB.Text += "项目" + project.name + " => 共 " + userCommit.Count + "\r\n";
                RunMessageTB.ScrollToEnd();
            }

            // TODO:保存数据
       

            GetDataBtn.IsEnabled = true;
        }


        /// <summary>
        /// 获取项目信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<Project>> GetProjectsAsync()
        {
            var url = ServerUrl.Text + projectUrl + "?per_page=100";
            hc.DefaultRequestHeaders.TryAddWithoutValidation("PRIVATE-TOKEN", PAT.Text);
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
            var response = await hc.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("获取commit失败,projectId:" + project.id);
                return default;
            }
            // 取出分页信息
            var total = response.Headers.Where(h => h.Key == "X-Total")
                .SingleOrDefault().Value?.FirstOrDefault();
            int pageSize = 100;
            var page = Convert.ToInt32(total) / pageSize + 1;

            for (int i = 1; i <= page; i++)
            {
                var pageUrl = url + "&page=" + i + "&per_page=" + pageSize;
                var _ = await hc.GetStringAsync(url);
                var commits = JsonSerializer.Deserialize<List<Commit>>(_);
                result.AddRange(commits);
            }
            return result;
        }

    }
}
