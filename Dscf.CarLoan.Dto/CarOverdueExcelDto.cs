using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    [DataContract]
    public class CarOverdueExcelDto
    {
        /// <summary>
        /// 应划扣日期
        /// </summary>
        [DataMember]
        public DateTime? RepayDate { get; set; }

        /// <summary>
        /// 核算月份
        /// </summary>
        [DataMember]
        public DateTime? Date { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        [DataMember]
        public int? DeptId { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [DataMember]
        public string SignCity { get; set; }
        /// <summary>
        /// 合同号
        /// </summary>
        [DataMember]
        public string CovenantNo { get; set; }

        /// <summary>
        /// 合同签署日期
        /// </summary>
        [DataMember]
        public DateTime? SigningDate { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [DataMember]
        public string IDCard { get; set; }
        /// <summary>
        /// 银行账户
        /// </summary>
        [DataMember]
        public string BankCard { get; set; }
        /// <summary>
        /// 所属银行
        /// </summary>
        [DataMember]
        public string BankName { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        [DataMember]
        public string SubBranchName { get; set; }
        /// <summary>
        /// 合同金额
        /// </summary>
        [DataMember]
        public decimal? Amount { get; set; }
        /// <summary>
        /// 合同类型
        /// </summary>
        [DataMember]
        public string ContractType { get; set; }
        /// <summary>
        /// 借款类型
        /// </summary>
        [DataMember]
        public string CarLoanTypeName { get; set; }
        /// <summary>
        /// 月利率
        /// </summary>
        [DataMember]
        public decimal? MonthRate { get; set; }
        /// <summary>
        /// 月利
        /// </summary>
        [DataMember]
        public decimal? MonthProfit { get; set; }

        /// <summary>
        /// 服务费率
        /// </summary>
        [DataMember]
        public decimal? MonthRateTotal { get; set; }

        /// <summary>
        /// 总服务费率
        /// </summary>
        [DataMember]
        public decimal? ComplexRateTotal { get; set; }
        /// <summary>
        /// 总服务费
        /// </summary>
        [DataMember]
        public decimal? ComplexTotal { get; set; }
        /// <summary>
        /// 咨询费率（占总服务费）
        /// </summary>
        [DataMember]
        public decimal? ConsultancyRate { get; set; }
        /// <summary>
        /// 咨询费
        /// </summary>
        [DataMember]
        public decimal? Consultancy { get; set; }

        /// <summary>
        /// 服务费率（占总服务费）
        /// </summary>
        [DataMember]
        public decimal? ServicesFeesRate { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        [DataMember]
        public decimal? ServicesFees { get; set; }

        /// <summary>
        /// 审核费率（占总服务费）
        /// </summary>
        [DataMember]
        public decimal? AuditFeesRate { get; set; }
        /// <summary>
        /// 审核费
        /// </summary>
        [DataMember]
        public decimal? AuditFees { get; set; }

        /// <summary>
        /// 代收手续费上限
        /// </summary>
        [DataMember]
        public decimal? CollectionFeeLimit { get; set; }

        /// <summary>
        /// 实收手续费
        /// </summary>
        [DataMember]
        public decimal? PaidFee { get; set; }
        /// <summary>
        /// 是否合理
        /// </summary>
        [DataMember]
        public bool? IsLogical { get; set; }
        /// <summary>
        /// 前期费用
        /// </summary>
        [DataMember]
        public decimal? InitialExpenses { get; set; }
        /// <summary>
        /// gps安装费
        /// </summary>
        [DataMember]
        public decimal? GPSInstallationFee { get; set; }
        /// <summary>
        /// 停车费
        /// </summary>
        [DataMember]
        public decimal? ParkingFee { get; set; }

        /// <summary>
        /// 流量费
        /// </summary>
        [DataMember]
        public decimal? TrafficCharges { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        [DataMember]
        public decimal? Margin { get; set; }
        /// <summary>
        /// 期数
        /// </summary>
        [DataMember]
        public int? ToalPeriod { get; set; }
        /// <summary>
        /// 月还本金
        /// </summary>
        [DataMember]
        public decimal? MonthRepayPrincipal { get; set; }
        /// <summary>
        /// 等额月还
        /// </summary>
        [DataMember]
        public decimal? EqualMonthlyReturn { get; set; }

        /// <summary>
        // 实际月还
        // </summary>
        [DataMember]
        public decimal? TheSameMonth { get; set; }
        /// <summary>
        /// 累计应还款总额
        /// </summary>
        public decimal? TotalShouldRepaid { get; set; }
        /// <summary>
        /// 体现业绩
        /// </summary>
        [DataMember]
        public decimal? DiscountPerformance { get; set; }
        /// <summary>
        /// 每月还款日
        /// </summary>
        [DataMember]
        public int? RepayDay { get; set; }
        /// <summary>
        /// 首次还款日期
        /// </summary>
        [DataMember]
        public DateTime? FirstRepaymentDate { get; set; }
        /// <summary>
        /// 末次还款日期
        /// </summary>
        [DataMember]
        public DateTime? LastRepaymentDate { get; set; }

        /// <summary>
        /// 实际放款日期
        /// </summary>
        [DataMember]
        public DateTime? ActualLoanDate { get; set; }
        /// <summary>
        /// 末期欠款金额
        /// </summary>
        [DataMember]
        public decimal? LastTermDueAmount { get; set; }
        /// <summary>
        /// 本期月还
        /// </summary>
        [DataMember]
        public decimal? MonthRepay { get; set; }
        /// <summary>
        /// 实际还款金额
        /// </summary>
        [DataMember]
        public decimal? ActualDeductAmount { get; set; }

        /// <summary>
        /// 实际还款日期
        /// </summary>
        [DataMember]
        public DateTime? ActualDeductDate { get; set; }
        /// <summary>
        /// 还款方式
        /// </summary>
        [DataMember]
        public string PayWayName { get; set; }
        /// <summary>
        /// 本期欠款金额
        /// </summary>
        [DataMember]
        public decimal? TermAmountOwed { get; set; }
        /// <summary>
        /// 本期是否还款成功
        /// </summary>
        [DataMember]
        public bool? IsDeductSucess { get; set; }
        /// <summary>
        /// 是否提前一次性还款
        /// </summary>
        [DataMember]
        public bool? IsDeductAll { get; set; }
        /// <summary>
        /// 累计已还期数
        /// </summary>
        [DataMember]
        public int? IsDeductTerm { get; set; }
        /// <summary>
        /// 剩余还款期数
        /// </summary>
        [DataMember]
        public int? NotDeductTerm { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Mark { get; set; }




        /// <summary>
        /// 逾期天数
        /// </summary>
        [DataMember]
        public int? OverDueDays { get; set; }
        /// <summary>
        /// 违约金
        /// </summary>
        [DataMember]
        public decimal? OverduePenalty { get; set; }
        /// <summary>
        /// 总罚息
        /// </summary>
        [DataMember]
        public decimal? DailyPenalties { get; set; }

        /// <summary>
        /// 罚息
        /// </summary>
        [DataMember]
        public decimal? DailyPenalty { get; set; }
        /// <summary>
        /// 本期应收款总额
        /// </summary>
        [DataMember]
        public decimal? TermTotal { get; set; }
    }
}
