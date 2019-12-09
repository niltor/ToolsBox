using System;
using System.Collections.Generic;
using System.Text;

namespace gitlab分析工具.Entity
{
    public class CommitsTask : DBBase
    {
        public Project Project { get; set; }
        public int Pid { get; set; }
        public int Page { get; set; }
    }
}
