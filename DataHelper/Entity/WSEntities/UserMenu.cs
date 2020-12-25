using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class UserMenu
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string MenuIds { get; set; }
    }
}
