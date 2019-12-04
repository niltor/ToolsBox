using System;
using System.Collections.Generic;
using System.Text;

namespace gitlab分析工具.Entity
{
    public class Commit
    {
        public string UserName { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ProjectName { get; set; }

        public int Additions { get; set; }
        public int Deletions { get; set; }
        public int Total { get; set; }

    }

}
