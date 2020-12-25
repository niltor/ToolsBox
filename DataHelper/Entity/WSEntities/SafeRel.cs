using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class SafeRel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cname { get; set; }
        public byte? IsShow { get; set; }
        public byte? IsShowForm { get; set; }
        public byte? IsShowPie { get; set; }
        public byte? IsSum { get; set; }
        public int? TypeId { get; set; }
        public string Year { get; set; }
        public int? Quarter { get; set; }
        public int? Sortby { get; set; }
        public int? TabId { get; set; }
        public int? IsExt { get; set; }
        public int? Pid { get; set; }
        public int? Level { get; set; }
        public int? Isleaf { get; set; }
        public string TreeCode { get; set; }
        public byte? IsEdit { get; set; }
        public int? Inputrole { get; set; }
        public string Pcoordinate { get; set; }
        public string Formula { get; set; }
        public DateTime? OptTime { get; set; }
        public byte? IsMerge { get; set; }
        public string Range { get; set; }
    }
}
