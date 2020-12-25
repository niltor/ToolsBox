using System;
using System.Collections.Generic;
using System.Text;

namespace DataHelper.Models
{
    public class PersonFileDto
    {
        public string RealName { get; set; }
        public string Sex { get; set; }
        public string Position { get; set; }
        public string Number { get; set; }
        public byte? IsFulltime { get; set; }
        public string Education { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public string OrgName { get; set; }
        public byte IsPartTime { get; set; } = 1;
        public string InternalPhone { get; set; }
        public string PublicPhone { get; set; }
        public byte? ContactRole { get; set; } = 0;

    }
}
