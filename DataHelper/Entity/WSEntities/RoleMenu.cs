using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class RoleMenu
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string MenuIds { get; set; }
    }
}
