using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.Model
{
    public class Loan_MonthRepayViewModel
    {
        /// <summary>
        /// 借款订单ID
        /// </summary>
        public int LoanOrderId { get; set; }

        /// <summary>
        /// 第几期
        /// </summary>
        public int? PeriodOrder { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        public decimal? ContractAmount { get; set; }

        /// <summary>
        /// 到手金额
        /// </summary>
        public decimal? AmountOfHand { get; set; }

        /// <summary>
        /// 总期数
        /// </summary>
        public int? ToalPeriod { get; set; }

        /// <summary>
        /// 还款时间
        /// </summary>
        public DateTime? RepayDate { get; set; }

        /// <summary>
        /// 是否划扣成功
        /// </summary>
        public bool? IsDeductSucess { get; set; }

        /// <summary>
        /// 服务费用总计
        /// </summary>
        public decimal? TotalServiceFee { get; set; }

        /// <summary>
        /// 月还款
        /// </summary>
        public decimal? MonthRepay { get; set; }

        /// <summary>
        /// 月还本金
        /// </summary>
        public decimal? MonthRepayPrincipal { get; set; }

        /// <summary>
        /// 月还利息
        /// </summary>
        public decimal? MonthInterest { get; set; }


        /// <summary>
        /// 剩余本金
        /// </summary>
        public decimal? RemainPrincipal { get; set; }

        /// <summary>
        /// 提前还款违约金
        /// </summary>
        public decimal? EarlyRepayPenalty { get; set; }

        /// <summary>
        /// 应还本息总额
        /// </summary>
        public decimal? TotalPricipalInterest { get; set; }
    }
}
