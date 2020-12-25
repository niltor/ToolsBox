using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class FlowAuditUser
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? ReportId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public int? Step { get; set; }
        public int? Status { get; set; }
        public string Content { get; set; }
        public DateTime? ContentTime { get; set; }
        public int? IsValid { get; set; }
        public byte? ActionType { get; set; }
    }
}
