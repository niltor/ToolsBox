using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordMd5 { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string Mobile { get; set; }
        public int? RoleId { get; set; }
        public int? RoleLevel { get; set; }
        public string RoleName { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public int? CountyId { get; set; }
        public string CountyName { get; set; }
        public int? SiteId { get; set; }
        public string SiteName { get; set; }
        public byte? Status { get; set; }
        public int? Creator { get; set; }
        public string CreatorName { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LogInTime { get; set; }
        public DateTime? LogOutTime { get; set; }
        public string Mac { get; set; }
        public byte? LogResult { get; set; }
        public int? LogWay { get; set; }
        public int? LogEntry { get; set; }
        public string BrowserVersion { get; set; }
        public string OsVersion { get; set; }
        public int? IsLogin { get; set; }
        public int? LoginErr { get; set; }
        public byte? IsChange { get; set; }
        public string CaptchaMd5 { get; set; }
    }
}
