using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class SafeProductAccidentImages
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? Pid { get; set; }
    }
}
