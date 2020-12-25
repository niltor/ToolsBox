using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class OuRel
    {
        public int Id { get; set; }
        public int? OuId { get; set; }
        public string OuName { get; set; }
        public string InName { get; set; }
        public string OutName { get; set; }
        public int? Sort { get; set; }
        public int? AreaId { get; set; }
    }
}
