using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class Area
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string OuName { get; set; }
        public int? Pid { get; set; }
        public string Category { get; set; }
        public int? Status { get; set; }
    }
}
