using System;
using System.Collections.Generic;
using System.Linq;
using MSDev.MetaWeblog;

namespace SyncToCnBlog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static bool SyncTo(List<PostInfo> blogs, string categories = null)
        {
            // 获取blogid
            string blogUrl = "http://www.cnblogs.com";
            string metablogUrl = "https://rpc.cnblogs.com/metaweblog/msdeveloper";
            var blogcon = new BlogConnectionInfo(blogUrl, metablogUrl, "320557", "niltor", "");
            var client = new Client(blogcon);
            var userBlogs = client.GetUsersBlogs();
            blogcon.BlogID = userBlogs.FirstOrDefault().BlogID;
            // 获取分类


            var cnCategories = client.GetCategories();
            var aimCategories = new List<string>();
            // 
            if (categories != null)
            {
                aimCategories = cnCategories.Where(c => c.Title.Contains(categories))
                    .Select(s => s.CategoryID)
                    .ToList();
            }
            // 添加文章
            try
            {
                foreach (var blog in blogs)
                {
                    blog.Categories = aimCategories;
                    client.NewPost(blog, null);

                    System.Console.WriteLine("=====:" + blog.Title + "==:" + aimCategories);
                }
                return true;
            }
            catch (System.Exception e)
            {

                System.Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
