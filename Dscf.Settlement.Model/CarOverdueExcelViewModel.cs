using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Settlement.Model
{
    public class CarOverdueExcelViewModel
    {
        /// <summary>
        /// 应划扣日期
        /// </summary>

        public DateTime? RepayDate { get; set; }

        /// <summary>
        /// 核算月份
        /// </summary>

        public DateTime? Date { get; set; }

        /// <summary>
        /// 城市
        /// </summary>

        public string SignCity { get; set; }
        /// <summary>
        /// 合同号
        /// </summary>

        public string CovenantNo { get; set; }

        /// <summary>
        /// 合同签署日期
        /// </summary>

        public DateTime? SigningDate { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>

        public string UserName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>

        public string IDCard { get; set; }
        /// <summary>
        /// 银行账户
        /// </summary>

        public string BankCard { get; set; }
        /// <summary>
        /// 所属银行
        /// </summary>

        public string BankName { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>

        public string SubBranchName { get; set; }
        /// <summary>
        /// 合同金额
        /// </summary>

        public decimal? Amount { get; set; }
        /// <summary>
        /// 合同类型
        /// </summary>

        public string ContractType { get; set; }
        /// <summary>
        /// 借款类型
        /// </summary>

        public string CarLoanTypeName { get; set; }
        /// <summary>
        /// 月利率
        /// </summary>

        public decimal? MonthRate { get; set; }
        /// <summary>
        /// 月利
        /// </summary>

        public decimal? MonthProfit { get; set; }

        /// <summary>
        /// 服务费率
        /// </summary>

        public decimal? MonthRateTotal { get; set; }

        /// <summary>
        /// 总服务费率
        /// </summary>

        public decimal? ComplexRateTotal { get; set; }
        /// <summary>
        /// 总服务费
        /// </summary>

        public decimal? ComplexTotal { get; set; }

        /// <summary>
        /// 咨询费
        /// </summary>

        public decimal? Consultancy { get; set; }


        /// <summary>
        /// 服务费
        /// </summary>

        public decimal? ServicesFees { get; set; }


        /// <summary>
        /// 审核费
        /// </summary>

        public decimal? AuditFees { get; set; }

        /// <summary>
        /// 代收手续费上限
        /// </summary>

        public decimal? CollectionFeeLimit { get; set; }

        /// <summary>
        /// 实收手续费
        /// </summary>

        public decimal? PaidFee { get; set; }
        /// <summary>
        /// 是否合理
        /// </summary>

        public bool? IsLogical { get; set; }
        /// <summary>
        /// 前期费用
        /// </summary>

        public decimal? InitialExpenses { get; set; }
        /// <summary>
        /// gps安装费
        /// </summary>

        public decimal? GPSInstallationFee { get; set; }
        /// <summary>
        /// 停车费
        /// </summary>

        public decimal? ParkingFee { get; set; }

        /// <summary>
        /// 流量费
        /// </summary>

        public decimal? TrafficCharges { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>

        public decimal? Margin { get; set; }
        /// <summary>
        /// 期数
        /// </summary>

        public int? ToalPeriod { get; set; }
        /// <summary>
        /// 月还本金
        /// </summary>

        public decimal? MonthRepayPrincipal { get; set; }
        /// <summary>
        /// 等额月还
        /// </summary>

        public decimal? EqualMonthlyReturn { get; set; }

        /// <summary>
        /// 实际月还
        /// </summary>
        public decimal? TheSameMonth { get; set; }
        /// <summary>
        /// 累计应还款总额
        /// </summary>
        public decimal? TotalShouldRepaid { get; set; }
        /// <summary>
        /// 体现业绩
        /// </summary>

        public decimal? DiscountPerformance { get; set; }
        /// <summary>
        /// 每月还款日
        /// </summary>

        public int? RepayDay { get; set; }
        /// <summary>
        /// 首次还款日期
        /// </summary>

        public DateTime? FirstRepaymentDate { get; set; }
        /// <summary>
        /// 末次还款日期
        /// </summary>

        public DateTime? LastRepaymentDate { get; set; }

        /// <summary>
        /// 实际放款日期
        /// </summary>

        public DateTime? ActualLoanDate { get; set; }
        /// <summary>
        /// 末期欠款金额
        /// </summary>

        public decimal? LastTermDueAmount { get; set; }
        /// <summary>
        /// 本期月还
        /// </summary>

        public decimal? MonthRepay { get; set; }
        /// <summary>
        /// 实际还款金额
        /// </summary>

        public decimal? ActualDeductAmount { get; set; }

        /// <summary>
        /// 实际还款日期
        /// </summary>

        public DateTime? ActualDeductDate { get; set; }
        /// <summary>
        /// 还款方式
        /// </summary>

        public string PayWayName { get; set; }
        /// <summary>
        /// 本期欠款金额
        /// </summary>

        public decimal? TermAmountOwed { get; set; }
        /// <summary>
        /// 本期是否还款成功
        /// </summary>

        public bool? IsDeductSucess { get; set; }
        /// <summary>
        /// 是否提前一次性还款
        /// </summary>

        public bool? IsDeductAll { get; set; }
        /// <summary>
        /// 累计已还期数
        /// </summary>

        public int? IsDeductTerm { get; set; }
        /// <summary>
        /// 剩余还款期数
        /// </summary>

        public int? NotDeductTerm { get; set; }
        /// <summary>
        /// 备注
        /// </summary>

        public string Mark { get; set; }

        /// <summary>
        /// 逾期天数
        /// </summary>
        public int? OverDueDays { get; set; }
        /// <summary>
        /// 违约金
        /// </summary>
        public decimal? OverduePenalty { get; set; }
        /// <summary>
        /// 罚息
        /// </summary>
        public decimal? DailyPenalties { get; set; }
        /// <summary>
        /// 本期应收款总额
        /// </summary>
        public decimal? TermTotal { get; set; }
    }
}
