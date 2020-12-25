using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class OrganizationInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TotalNumber { get; set; }
        public int? Level { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? OrgId { get; set; }
        public string OrgName { get; set; }
        public int? DepartmentId { get; set; }
        public int? LeaderId { get; set; }
        public int? LeaderStatus { get; set; }
        public string Leader { get; set; }
        public string LeaderInnerPhone { get; set; }
        public string LeaderPublicPhone { get; set; }
        public string LeaderPhone { get; set; }
        public string LeaderEmail { get; set; }
        public int? PrincipalId { get; set; }
        public int? PrincipalStatus { get; set; }
        public string Principal { get; set; }
        public string PrincipalInnerPhone { get; set; }
        public string PrincipalPublicPhone { get; set; }
        public string PrincipalPhone { get; set; }
        public string PrincipalEmail { get; set; }
        public int? PrincipalLeaderId { get; set; }
        public int? PrincipalLeaderStatus { get; set; }
        public string PrincipalLeader { get; set; }
        public string PrincipalLeaderInnerPhone { get; set; }
        public string PrincipalLeaderPublicPhone { get; set; }
        public string PrincipalLeaderPhone { get; set; }
        public string PrincipalLeaderEmail { get; set; }
        public int? ContactId { get; set; }
        public int? ContactStatus { get; set; }
        public string Contact { get; set; }
        public string ContactInnerPhone { get; set; }
        public string ContactPublicPhone { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public int? FullTimeNumber { get; set; }
        public int? PartTimeNumber { get; set; }
        public int? MainFullTimeNumber { get; set; }
        public int? MainPartTimeNumber { get; set; }
    }
}
