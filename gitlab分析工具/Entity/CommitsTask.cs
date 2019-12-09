using System;
using System.Collections.Generic;
using System.Text;

namespace gitlab分析工具.Entity
{
    public class CommitsTask : DBBase
    {
        public int ProjectId { get; set; }
        public int Page { get; set; }
    }
}
