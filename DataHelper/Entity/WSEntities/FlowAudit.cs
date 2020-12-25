using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class FlowAudit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Step { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public int? RoleLevel { get; set; }
    }
}
