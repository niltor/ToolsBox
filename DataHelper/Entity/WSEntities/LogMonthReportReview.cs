using System;
using System.Collections.Generic;

namespace DataHelper.Entity.WSEntities
{
    public partial class LogMonthReportReview
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? Result { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }
        public string RealName { get; set; }
        public int? ReportId { get; set; }
        public byte? ActionType { get; set; }
    }
}
