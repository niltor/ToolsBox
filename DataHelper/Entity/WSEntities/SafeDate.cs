using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class SafeDate
    {
        public int Id { get; set; }
        public int? TabId { get; set; }
        public int? Quarter { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Year { get; set; }
    }
}
