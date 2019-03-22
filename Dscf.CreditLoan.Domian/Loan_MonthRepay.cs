using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain
{
    public class Loan_MonthRepay
    {
        public int RepayId { get; set; }

        /// <summary>
        /// LoanOrderId
        /// </summary>
        public int? LoanOrderId { get; set; }

        /// <summary>
        /// PeriodOrder
        /// </summary>
        public int? PeriodOrder { get; set; }

        /// <summary>
        /// ContractAmount
        /// </summary>
        public decimal? ContractAmount { get; set; }

        /// <summary>
        /// AmountOfHand
        /// </summary>
        public decimal? AmountOfHand { get; set; }

        /// <summary>
        /// ToalPeriod
        /// </summary>
        public int? ToalPeriod { get; set; }

        /// <summary>
        /// TotalServiceFee
        /// </summary>
        public decimal? TotalServiceFee { get; set; }

        /// <summary>
        /// MonthRate
        /// </summary>
        public decimal? MonthRate { get; set; }

        /// <summary>
        /// MonthRepay
        /// </summary>
        public decimal? MonthRepay { get; set; }

        /// <summary>
        /// MonthRepayPrincipal
        /// </summary>
        public decimal? MonthRepayPrincipal { get; set; }

        /// <summary>
        /// MonthInterest
        /// </summary>
        public decimal? MonthInterest { get; set; }

        /// <summary>
        /// RemainPrincipal
        /// </summary>
        public decimal? RemainPrincipal { get; set; }

        /// <summary>
        /// OneRepayAll
        /// </summary>
        public decimal? OneRepayAll { get; set; }

        /// <summary>
        /// ReturnServiceFee
        /// </summary>
        public decimal? ReturnServiceFee { get; set; }

        /// <summary>
        /// EarlyRepayPenalty
        /// </summary>
        public decimal? EarlyRepayPenalty { get; set; }

        /// <summary>
        /// TotalPricipalInterest
        /// </summary>
        public decimal? TotalPricipalInterest { get; set; }

        /// <summary>
        /// OverduePenalty
        /// </summary>
        public decimal? OverduePenalty { get; set; }

        /// <summary>
        /// DailyPenalty
        /// </summary>
        public decimal? DailyPenalty { get; set; }

        /// <summary>
        /// RepayDate
        /// </summary>
        public DateTime? RepayDate { get; set; }

        /// <summary>
        /// IsDeductSucess
        /// </summary>
        public bool? IsDeductSucess { get; set; }

        /// <summary>
        /// ActualDeductAmount
        /// </summary>
        public decimal? ActualDeductAmount { get; set; }

        /// <summary>
        /// DebtOptId
        /// </summary>
        public int? DebtOptId { get; set; }

        /// <summary>
        /// IsRemind
        /// </summary>
        public bool? IsRemind { get; set; }

        /// <summary>
        /// 已划扣逾期违约金
        /// </summary>
        public decimal? DeductOverduePenalty { get; set; }

        /// <summary>
        /// 已划扣每日罚息总额
        /// </summary>
        public decimal? DeductDailyPenalty { get; set; }

        /// <summary>
        /// 已划扣月还款额
        /// </summary>
        public decimal? DeductMonthRepay { get; set; }

        /// <summary>
        /// 时间还款日期
        /// </summary>

        public DateTime? ActualDeductDate { get; set; }


    }
}
