using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class SafeProductAccident
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Location { get; set; }
        public string Classification { get; set; }
        public DateTime? Time { get; set; }
        public string Level { get; set; }
        public int? BlockHours { get; set; }
        public float? EconomyLose { get; set; }
        public string DutyClassification { get; set; }
        public int? SelfDeathNumber { get; set; }
        public int? OtherDeathNumber { get; set; }
        public int? SelfHeavyInjuredNumber { get; set; }
        public int? OtherHeavyInjuredNumber { get; set; }
        public int? SelfInjuredNumber { get; set; }
        public int? OtherInjuredNumber { get; set; }
        public string Detail { get; set; }
        public string Auditor { get; set; }
        public int? AuditorId { get; set; }
        public string InputUser { get; set; }
        public int? InputUserId { get; set; }
        public int? InputUserLevel { get; set; }
        public string MainPrincipal { get; set; }
        public string Leader { get; set; }
        public int? MainPrincipalId { get; set; }
        public int? LeaderId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? Status { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? OrgId { get; set; }
        public string OrgName { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Step { get; set; }
    }
}
