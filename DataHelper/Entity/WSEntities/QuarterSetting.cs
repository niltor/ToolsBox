using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class QuarterSetting
    {
        public int Id { get; set; }
        public int? Month { get; set; }
        public int? Quarter { get; set; }
        public int? Year { get; set; }
    }
}
