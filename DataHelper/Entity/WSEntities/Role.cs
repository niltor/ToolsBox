using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Level { get; set; }
        public int? Sort { get; set; }
        public int? Status { get; set; }
        public int? IsAdmin { get; set; }
    }
}
