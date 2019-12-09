using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gitlab分析工具.Entity
{
    public class DBBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Status Status { get; set; } = Status.Default;
    }

    public enum Status
    {
        Default,
        InValid
    }
}
