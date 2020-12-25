using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class WorkOrganization1
    {
        public int OuId { get; set; }
        public string OuName { get; set; }
        public string OuLevel { get; set; }
        public int? DepartmentId { get; set; }
        public string Department { get; set; }
        public int? CityId { get; set; }
        public string City { get; set; }
        public int? ProvinceId { get; set; }
        public string Province { get; set; }
    }
}
