using System;
using System.Collections.Generic;
using System.Text;
using gitlab分析工具.Entity;
using Microsoft.EntityFrameworkCore;

namespace gitlab分析工具
{
    public class LocalContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<CommitsTask> CommitsTasks { get; set; }

        public DbSet<Commit> Commits { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
