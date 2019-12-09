using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using gitlab分析工具.Models;

namespace gitlab分析工具
{
    public class GLService
    {
        readonly string projectUrl = "/api/v4/projects";
        readonly string commitUrl = "/api/v4/projects/:id/repository/commits?all=true&with_stats=true";
        private string baseUrl = "";
        private string pat = "";
        private HttpClient hc;
        public GLService(string baseUrl, string pat)
        {
            this.baseUrl = baseUrl;
            this.pat = pat;
            hc = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(5)
            };
        }


        /// <summary>
        /// 项目信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<Entity.Project>> GetProjectsAsync()
        {
            var url = baseUrl + projectUrl + "?per_page=100";
            hc.DefaultRequestHeaders.TryAddWithoutValidation("PRIVATE-TOKEN", pat);
            try
            {
                var response = await hc.GetStringAsync(url);
                var projects = JsonSerializer.Deserialize<List<Project>>(response);
                var data = projects.Select(s => new Entity.Project
                {
                    ProjectId = s.id,
                    Name = s.name_with_namespace
                }).ToList();

                using (var ctx = new LocalContext())
                {
                    // TODO:查询去重
                    var currentProjects = ctx.Projects.ToList();
                    data = data.Where(d => !currentProjects.Select(cp => cp.ProjectId).Contains(d.ProjectId))
                        .ToList();
                    ctx.Projects.AddRange(data);
                    await ctx.SaveChangesAsync();
                    return data;
                }
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// 创建commit任务
        /// </summary>
        /// <returns></returns>
        public async Task<int> BuildTask()
        {
            using (var ctx = new LocalContext())
            {
                var projects = ctx.Projects.Where(p => p.Status == Entity.Status.Default)
                    .ToList();
                var task = new List<Entity.CommitsTask>();
                foreach (var project in projects)
                {
                    var url = baseUrl + commitUrl.Replace(":id", project.Id.ToString());
                    try
                    {
                        var response = await hc.GetAsync(url);
                        if (!response.IsSuccessStatusCode)
                        {
                            continue;
                        }
                        // 取出分页信息
                        var total = response.Headers.Where(h => h.Key == "X-Total")
                            .SingleOrDefault().Value?.FirstOrDefault();
                        int pageSize = 100;
                        var page = Convert.ToInt32(total) / pageSize + 1;

                        // 插入任务
                        for (int i = 1; i <= page; i++)
                        {
                            task.Add(new Entity.CommitsTask
                            {
                                Pid = project.ProjectId,
                                Page = i,
                            });
                        }
                        ctx.AddRange(task);
                        project.Status = Entity.Status.InValid;
                    }
                    catch (Exception)
                    {
                        return default;
                    }
                }
                await ctx.SaveChangesAsync();
                return task.Count;
            }
        }

        /// <summary>
        /// 获取commits数据
        /// </summary>
        /// <param name="project"></param>
        /// <param name="task"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<Entity.Commit>> GetCommits(Entity.CommitsTask task, int pageSize = 100)
        {
            var url = baseUrl + commitUrl.Replace(":id", task.Pid.ToString());
            var pageUrl = url + "&page=" + task.Page + "&per_page=" + pageSize;
            try
            {
                var _ = await hc.GetStringAsync(pageUrl);
                var commits = JsonSerializer.Deserialize<List<Commit>>(_);
                if (commits != null)
                {
                    var currentCommit = commits.Select(s => new Entity.Commit
                    {
                        Additions = s.stats.additions,
                        CreatedTime = s.created_at,
                        Deletions = s.stats.deletions,
                        ProjectName = task.Project?.Name,
                        Total = s.stats.total,
                        UserName = s.committer_name,

                    }).ToList();
                    return currentCommit;
                }
            }
            catch (Exception)
            {
                return default;
            }
            return default;
        }
    }
}
