using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class FlowLogAll
    {
        public int Id { get; set; }
        public int? FlowId { get; set; }
        public int? Step { get; set; }
        public int? Uid { get; set; }
        public DateTime? OptTime { get; set; }
        public int? CheckResult { get; set; }
        public int? Status { get; set; }
        public int? TableId { get; set; }
        public string TableName { get; set; }
        public string Reason { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
    }
}
