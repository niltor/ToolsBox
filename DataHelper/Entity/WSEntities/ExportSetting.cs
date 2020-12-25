using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class ExportSetting
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
        public int? TabId { get; set; }
        public int? StartRow { get; set; }
        public int? EndRow { get; set; }
        public int? DataRow { get; set; }
        public int? Tab { get; set; }
    }
}
