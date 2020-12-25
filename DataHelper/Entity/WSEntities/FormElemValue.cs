using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class FormElemValue
    {
        public int Id { get; set; }
        public string TypeId { get; set; }
        public string Value { get; set; }
        public int? Code { get; set; }
    }
}
