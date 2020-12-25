using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class SafeErrorLogs
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public int? Uid { get; set; }
        public string Username { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Status { get; set; }
        public string Filepath { get; set; }
    }
}
