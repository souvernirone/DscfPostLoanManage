using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    public class V_LoanOrderOverdueInfoDto
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int LoanOrderId { get; set; }
        /// <summary>
        /// 累计逾期本金
        /// </summary>
        public decimal? OverduePrincipalSum { get; set; }

        /// <summary>
        /// 首逾日期
        /// </summary>
        public DateTime? FirstOverdueTime { get; set; }

        /// <summary>
        /// 逾期次数
        /// </summary>
        public int? OverdueCount { get; set; }

        /// <summary>
        /// 债权状态
        /// </summary>
        public int? CreditStatus { get; set; }
    }
}
