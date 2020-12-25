using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataHelper.Entity.WSEntities
{
    public partial class PersonFile
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string RealName { get; set; }
        public string Sex { get; set; }
        public string Position { get; set; }
        public string Number { get; set; }
        public byte? IsFulltime { get; set; }
        public string Education { get; set; }
        public byte? IsPartTime { get; set; }
        public byte? RegSafetyEngineer { get; set; }
        public byte? RegFireEngineer { get; set; }
        public string Remark { get; set; }
        public string Phone { get; set; }
        public string InternalPhone { get; set; }
        public string PublicPhone { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public int? ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public int? OrgId { get; set; }
        public string OrgName { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? Status { get; set; }
        public int? Step { get; set; }
        public DateTime? Birthday { get; set; }
        public string InputUser { get; set; }
        public int? InputUserLevel { get; set; }
        public int? InputUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public byte? IsOnJob { get; set; }
        public byte? IsDeleted { get; set; }
        public byte? ActionType { get; set; }
        public byte? IsLeader { get; set; }
        public byte? ContactRole { get; set; }
        public byte? ContractType { get; set; }
    }
}
