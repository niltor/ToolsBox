using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace gitlab分析工具
{
    public class LocalContext : DbContext
    {

        public LocalContext()
        {
        }
        public LocalContext(DbContextOptions<LocalContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(@"Data Source=data.db;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
