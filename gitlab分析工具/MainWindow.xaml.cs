using CsvHelper;
using gitlab分析工具.Models;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Controls;

namespace gitlab分析工具
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            SaveToCsvBtn.IsEnabled = false;

            var service = new GLService(ServerUrl.Text, PAT.Text);
            // 获取项目
            AppendMessage("开始获取项目信息");
            var projects = await service.GetProjectsAsync();
            if (projects?.Count > 0)
            {
                AppendMessage(projects.Count + "个新项目");
            }
            else
            {
                AppendMessage("无新增项目");
            }
            AppendMessage("开始构建任务,请耐心等待!");
            var count = await service.BuildTask(RunMessageTB);
            if (count > 0)
            {
                AppendMessage(count + "个任务构建完成");
            }
            else
            {
                AppendMessage("无新任务构建");
            }
            AppendMessage("开始执行任务");
            using (var ctx = new LocalContext())
            {
                var tasks = ctx.CommitsTasks.Where(ct => ct.Status == Entity.Status.Default)
                    .Include(ct => ct.Project)
                    .ToList();

                if (tasks != null)
                {
                    foreach (var task in tasks)
                    {
                        AppendMessage("执行任务" + task.Id + $"=>{task.Project?.Name}:{task.Project.ProjectId}[{task.Page}]");
                        // 获取提交
                        var commits = await service.GetCommits(task);
                        if (commits != null)
                        {
                            ctx.AddRange(commits);
                            task.Status = Entity.Status.InValid;
                            await ctx.SaveChangesAsync();
                            AppendMessage("任务:" + task.Id + "执行完成");
                        }
                        else
                        {
                            AppendMessage("任务:" + task.Id + "执行失败");
                        }
                    }
                }

            }
            RunMessageTB.Text += "已全部采集完成\r\n";
            RunMessageTB.ScrollToEnd();
            GetDataBtn.IsEnabled = true;
            SaveToCsvBtn.IsEnabled = true;
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
                using (var ctx = new LocalContext())
                {
                    var data = ctx.Commits.ToList();
                    using (var writer = new StreamWriter(dlg.FileName))
                    {
                        using (var csv = new CsvWriter(writer))
                        {
                            csv.WriteRecords(data);
                        }
                    }
                }
                MessageBox.Show("保存成功");
                SaveToCsvBtn.IsEnabled = true;
            }
        }



        private void AppendMessage(string message)
        {
            RunMessageTB.Text += message + "\r\n";
            RunMessageTB.ScrollToEnd();
        }
    }
}
