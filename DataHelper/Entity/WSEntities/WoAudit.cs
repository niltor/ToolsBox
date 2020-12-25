using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class WoAudit
    {
        public int Id { get; set; }
        public string WorkNumber { get; set; }
        public int? WnOuid { get; set; }
        public string WnUsername { get; set; }
        public string WnRealname { get; set; }
        public DateTime? WnTime { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountyId { get; set; }
        public string CountyName { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public DateTime? CDate { get; set; }
        public int? Result { get; set; }
        public string Comment { get; set; }
        public int CUid { get; set; }
        public string CName { get; set; }
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
