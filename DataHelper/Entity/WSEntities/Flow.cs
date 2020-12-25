using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class Flow
    {
        public int? Id { get; set; }
        public int? FlowId { get; set; }
        public int? Step { get; set; }
        public string FlowName { get; set; }
        public string TableName { get; set; }
        public int? RoleId { get; set; }
        public int? Mount { get; set; }
        public int? Level { get; set; }
        public string RoleName { get; set; }
    }
}
