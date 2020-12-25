using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class SafeProductOnsite
    {
        public int Id { get; set; }
        public int? OrgId { get; set; }
        public DateTime? CheckDate { get; set; }
        public string Leaders { get; set; }
        public int? CityOrgId { get; set; }
        public int? SupportPartmentId { get; set; }
        public string SupportPartment { get; set; }
        public string ClassGroup { get; set; }
        public string CityOrgName { get; set; }
        public string OrgName { get; set; }
        public string CheckForm { get; set; }
        public string CheckContent { get; set; }
        public byte? HasIssue { get; set; }
        public string IssueType { get; set; }
        public string Issue { get; set; }
        public DateTime? TimeLimit { get; set; }
        public DateTime? CreatedTime { get; set; }
        public byte? Rectify { get; set; }
        public int? Status { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public string Leader { get; set; }
        public int? LeaderId { get; set; }
        public int? MainPrincipalId { get; set; }
        public string MainPrincipal { get; set; }
        public int? InputUserId { get; set; }
        public int? InputUserLevel { get; set; }
        public string InputUser { get; set; }
        public int? IssueNumber { get; set; }
        public int? SolveNumber { get; set; }
        public int? NoSolveNumber { get; set; }
        public int? Step { get; set; }
    }
}
