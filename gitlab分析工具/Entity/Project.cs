using System;
using System.Collections.Generic;
using System.Text;

namespace gitlab分析工具.Entity
{
    public class Project : DBBase
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }

        public ICollection<CommitsTask> CommitsTasks { get; set; }
    }
}
