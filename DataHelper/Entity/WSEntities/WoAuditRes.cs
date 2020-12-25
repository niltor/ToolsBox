using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class WoAuditRes
    {
        public int Id { get; set; }
        public string WorkNumber { get; set; }
        public int? Result { get; set; }
        public int? RoleId { get; set; }
    }
}
