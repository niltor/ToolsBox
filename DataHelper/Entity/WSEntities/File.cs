using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Ext { get; set; }
        public string Mokuai { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
