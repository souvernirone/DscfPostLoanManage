using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    /// <summary>
    /// 车贷月还信息
    /// </summary>
    [DataContract]
    public class LoanMonthRepayDto
    {
        /// <summary>
        /// RepayId
        /// </summary>
        [DataMember]
        public int RepayId { get; set; }
        /// <summary>
        /// 借款订单Id
        /// </summary>
        [DataMember]
        public int? LoanOrderId { get; set; }

        /// <summary>
        /// 第几期
        /// </summary>
        [DataMember]
        public int? PeriodOrder { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        [DataMember]
        public decimal? ContractAmount { get; set; }

        /// <summary>
        /// 到手金额
        /// </summary>
        [DataMember]
        public decimal? AmountOfHand { get; set; }

        /// <summary>
        /// 总期数
        /// </summary>
        [DataMember]
        public int? ToalPeriod { get; set; }

        /// <summary>
        /// 服务费用总计
        /// </summary>
        [DataMember]
        public decimal? TotalServiceFee { get; set; }

        /// <summary>
        /// 月利率
        /// </summary>
        [DataMember]
        public decimal? MonthRate { get; set; }

        /// <summary>
        /// 月还款
        /// </summary>
        [DataMember]
        public decimal? MonthRepay { get; set; }

        /// <summary>
        /// 月还本金
        /// </summary>
        [DataMember]
        public decimal? MonthRepayPrincipal { get; set; }

        /// <summary>
        /// 月还利息
        /// </summary>
        [DataMember]
        public decimal? MonthInterest { get; set; }

        /// <summary>
        /// 剩余本金
        /// </summary>
        [DataMember]
        public decimal? RemainPrincipal { get; set; }

        /// <summary>
        /// 一次性还款金额
        /// </summary>
        [DataMember]
        public decimal? OneRepayAll { get; set; }

        /// <summary>
        /// 退服务费
        /// </summary>
        [DataMember]
        public decimal? ReturnServiceFee { get; set; }

        /// <summary>
        /// 提前还款违约金
        /// </summary>
        [DataMember]
        public decimal? EarlyRepayPenalty { get; set; }

        /// <summary>
        /// 应还本息总额
        /// </summary>
        [DataMember]
        public decimal? TotalPricipalInterest { get; set; }

        /// <summary>
        /// 逾期违约金
        /// </summary>
        [DataMember]
        public decimal? OverduePenalty { get; set; }

        /// <summary>
        /// 每天罚息
        /// </summary>
        [DataMember]
        public decimal? DailyPenalty { get; set; }

        /// <summary>
        /// 还款日期
        /// </summary>
        [DataMember]
        public DateTime? RepayDate { get; set; }

        /// <summary>
        /// 是否划扣成功
        /// </summary>
        [DataMember]
        public bool IsDeductSucess { get; set; }

        /// <summary>
        /// 实际划扣金额
        /// </summary>
        [DataMember]
        public decimal? ActualDeductAmount { get; set; }

        /// <summary>
        /// 催收人
        /// </summary>
        [DataMember]
        public int? DebtOptId { get; set; }

        /// <summary>
        /// 提醒标识
        /// </summary>
        [DataMember]
        public int? IsRemind { get; set; }

        /// <summary>
        /// 已划扣逾期违约金
        /// </summary>
        [DataMember]
        public decimal? DeductOverduePenalty { get; set; }

        /// <summary>
        /// 已划扣每日罚息总额
        /// </summary>
        [DataMember]
        public decimal? DeductDailyPenalty { get; set; }

        /// <summary>
        /// 已划扣月还款额
        /// </summary>
        [DataMember]
        public decimal? DeductMonthRepay { get; set; }

        [DataMember]
        public int GiveUpExtension { get; set; }
        [DataMember]
        public DateTime? ActualDeductDate { get; set; }
    }
}
