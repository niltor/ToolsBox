using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Pid { get; set; }
        public string Url { get; set; }
        public string Pids { get; set; }
        public string Icon { get; set; }
        public int? Enable { get; set; }
        public int? Hide { get; set; }
        public int? Type { get; set; }
        public int? Sort { get; set; }
    }
}
