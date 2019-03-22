using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.Model
{
    /// <summary>
    /// 信用借款债权信息
    /// </summary>
    public class CreditClaimsInfo
    {
        /// <summary>
        /// 还款时间
        /// </summary>
        public DateTime? RepayDate { get; set; }

        /// <summary>
        /// 逾期天数
        /// </summary>
        public int OverdueDayCount { get; set; }

        /// <summary>
        /// 月还款
        /// </summary>
        public decimal? MonthRepay { get; set; }

        /// <summary>
        /// 逾期违约金
        /// </summary>
        public decimal? OverduePenalty { get; set; }

        /// <summary>
        /// 每期罚息总和
        /// </summary>
        public decimal? DailyPenaltySumPerPeriod { get; set; }

        /// <summary>
        /// 每期剩余本金
        /// </summary>
        public decimal? OverduePrincipalPerPeriod { get; set; }

        /// <summary>
        /// 剩余逾期违约金
        /// </summary>
        public decimal? RemianOverduePenalty { get; set; }

        /// <summary>
        /// 剩余每日罚息总额
        /// </summary>
        public decimal? RemianDailyPenalty { get; set; }

        /// <summary>
        /// 剩余月还款额
        /// </summary>
        public decimal? RemianMonthRepay { get; set; }

        /// <summary>
        /// 已划扣金额总和
        /// </summary>
        public decimal? DeductAmountSumPerPeriod { get; set; }
    }
}
