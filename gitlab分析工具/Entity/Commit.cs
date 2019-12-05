using System;
using System.Collections.Generic;
using System.Text;

namespace gitlab分析工具.Entity
{
    public class Commit
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 添加
        /// </summary>
        public int Additions { get; set; }
        /// <summary>
        /// 删除
        /// </summary>
        public int Deletions { get; set; }
        /// <summary>
        /// 变动
        /// </summary>
        public int Total { get; set; }

    }

}
