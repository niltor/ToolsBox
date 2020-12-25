using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class FormElemType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public byte Hide { get; set; }
        public string Jingdu { get; set; }
    }
}
