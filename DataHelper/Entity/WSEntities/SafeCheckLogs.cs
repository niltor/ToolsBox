using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class SafeCheckLogs
    {
        public int Id { get; set; }
        public byte Type { get; set; }
        public int RecordId { get; set; }
        public int AdminId { get; set; }
        public DateTime? AddTime { get; set; }
        public string Url { get; set; }
        public byte? IsCount { get; set; }
        public string Reason { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int? Status { get; set; }
        public int? RoleId { get; set; }
        public int? CurStep { get; set; }
    }
}
