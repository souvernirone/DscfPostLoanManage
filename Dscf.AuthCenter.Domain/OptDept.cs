using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Domain
{
    public class OptDept
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 催收人员主键ID
        /// </summary>
        public int? OptId { get; set; }

        /// <summary>
        /// 营业部主键ID
        /// </summary>

        public int? DeptId { get; set; }

        /// <summary>
        /// 部门来源-DSUserCenter OR P2P 库
        /// 1-DSUserCenter
        /// 2-P2P
        /// </summary>
        public int? SourceType { get; set; }

    }
}
