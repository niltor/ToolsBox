using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace gitlab分析工具.Entity
{
    public class DBBase
    {
        [Key]
        public int Id { get; set; }
        public Status Status { get; set; } = Status.Default;
    }

    public enum Status
    {
        Default,
        InValid
    }
}
