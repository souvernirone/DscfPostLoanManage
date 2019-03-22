using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Settlement.Model
{
    public class CarFinancialExportExcleViewModel
    {
        /// <summary>
        /// 借款订单编号
        /// </summary>
        
        public int OrderId { get; set; }

        /// <summary>
        /// 核算月份
        /// </summary>
        
        public string CalculateMonthStr { get; set; }
        /// <summary>
        /// 签约城市
        /// </summary>
        
        public string SignCity { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        
        public string Contract { get; set; }

        /// <summary>
        /// 面签时间
        /// </summary>
        
        public string SignDateStr { get; set; }
        /// <summary>
        /// 客户信息
        /// </summary>
        
        public int? UserId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        
        public string Name { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        
        public string IDCard { get; set; }

        /// <summary>
        /// 划扣银行
        /// </summary>
        
        public string DeductBankName { get; set; }

        /// <summary>
        /// 划扣银行支行
        /// </summary>
        
        public string DeductBranchBank { get; set; }

        /// <summary>
        /// 划扣银行账户
        /// </summary>
        
        public string DeductBankAccount { get; set; }

        /// <summary>
        /// 合同额
        /// </summary>
        
        public decimal? Amount { get; set; }

        /// <summary>
        /// 借款类型
        /// </summary>
        
        public string ProductName { get; set; }

        /// <summary>
        /// 月利率
        /// </summary>
        
        public decimal? MonthlyRate { get; set; }

        /// <summary>
        /// 月利--[Amount] 借款金额批款额）*（【月利率】	1%
        /// </summary>
        
        public decimal? Monthly { get; set; }

        /// <summary>
        /// 服务费率
        /// </summary>
        
        public decimal? ServiceRate { get; set; }

        /// <summary>
        /// 总服务费--IF(FIND("期",合同类型),合同金额*服务费率*期数,合同金额*服务费率)
        /// </summary>
        
        public decimal? TotalServiceCharge { get; set; }

        /// <summary>
        /// 咨询费--【总服务费】*0.4
        /// </summary>
        
        public decimal? ConsultationFee { get; set; }

        /// <summary>
        /// 审核费--【总服务费】*0.1
        /// </summary>
        
        public decimal? AuditFee { get; set; }

        /// <summary>
        /// 服务费--【总服务费】-【咨询费】-【服务费】
        /// </summary>
        
        public decimal? ServiceCharge { get; set; }

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
        
        public bool IsReasonable { get; set; }

        /// <summary>
        /// 前期费用--【总服务费】+实收手续费+【前期费用】 +【GPS安装费】+【停车费】+【保证金】
        /// </summary>
        
        public decimal? InitialExpenses { get; set; }

        /// <summary>
        /// GPS安装费--IF(LEFT(借款类型,3)="GPS",IF(合同金额>200000,"1500","1000"),"0")
        /// </summary>
        
        public decimal? GPSInstallationFee { get; set; }

        /// <summary>
        /// 停车费--IF(LEFT(借款类型,3)="GPS","0","500")
        /// </summary>
        
        public decimal? ParkingFee { get; set; }

        /// <summary>
        /// 流量费--IF(LEFT(借款类型,3)="GPS","100","")
        /// </summary>
        
        public decimal? TrafficCharges { get; set; }

        /// <summary>
        /// 保证金--ROUND(IF(借款类型="GPS90",合同金额*2%,IF(LEFT(借款类型,3)="GPS","3%","0")*借款类型),2)
        /// </summary>
        
        public decimal? Margin { get; set; }


        /// <summary>
        /// 借款期限批款期
        /// </summary>
        
        public int? Term { get; set; }

        /// <summary>
        /// 月还本金--ROUND(IFERROR(IF(FIND("期",借款类型),合同金额/期数,0),0),2)
        /// </summary>
        
        public decimal? MonthAlsoPrincipal { get; set; }

        /// <summary>
        /// 等额月还--IF(FIND("期",借款类型),合同金额/期数+月利,0)
        /// </summary>
        
        public decimal? EqualMonthlyReturn { get; set; }
        /// <summary>
        /// 实际月还--ROUND(IF(LEFT(借款类型,3)="GPS",【月还本金】+【月利】+【流量费】,【月利】+【月还本金】+【停车费】),2)
        /// </summary>
        
        public decimal? TheSameMonth { get; set; }

        /// <summary>
        /// 累计应还款总额--ROUND(IFERROR(IF(FIND("期",借款类型),【实际月还】*期数,0),0),2)
        /// </summary>
        
        public decimal? TotalShouldRepaid { get; set; }

        /// <summary>
        /// 折标业绩--  ROUND(IF(OR(借款类型="押车6期",借款类型="GPS6期"),50%*合同金额,IF(OR(借款类型="押车30",借款类型="GPS30"),10%*合同金额,IF(OR(借款类型="押车60",借款类型="GPS60"),20%*合同金额,IF(OR(借款类型="押车90",借款类型="GPS90"),30%*合同金额,100%*合同金额)))),2)
        /// </summary>
        
        public decimal? DiscountPerformance { get; set; }

        /// <summary>
        /// 扣款日/每月还款日
        /// </summary>
        
        public int? DeductDate { get; set; }

        /// <summary>
        /// 首次还款日期
        /// </summary>
        
        public string FirstRepaymentDateStr { get; set; }

        /// <summary>
        /// 末次还款日期
        /// </summary>
        
        public string LastRepaymentDateStr { get; set; }

        /// <summary>
        /// 实际放款日期
        /// </summary>
        
        public string ActualLenderDateStr { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        
        public string CarModels { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        
        public string CarNumberPlate { get; set; }

        /// <summary>
        /// 客户经理员工编号
        /// </summary>
        
        public int? CustomerManager { get; set; }

        /// <summary>
        /// 客户经理姓名
        /// </summary>
        
        public string CustomerManagerName { get; set; }

        /// <summary>
        /// 客户经理联系电话
        /// </summary>
        
        public string CustomerManagerPhone { get; set; }

        /// <summary>
        /// 团队经理ID
        /// </summary>
        
        public int? TeamManager { get; set; }

        /// <summary>
        /// 团队名称
        /// </summary>
        
        public string TeamManagerGroup { get; set; }

        /// <summary>
        /// 团队经理项目
        /// </summary>
        
        public string TeamManagerName { get; set; }

        /// <summary>
        /// 营业部经理姓名
        /// </summary>
        
        public string SalesManagerName { get; set; }

        /// <summary>
        /// 营业部经理员工编号
        /// </summary>
        
        public string SalesManagerNo { get; set; }

        /// <summary>
        /// 城市经理姓名
        /// </summary>
        
        public string CityManagerName { get; set; }

        /// <summary>
        /// 城市经理员工编号
        /// </summary>
        
        public string CityManagerNo { get; set; }

        /// <summary>
        /// 大区经理姓名
        /// </summary>
        
        public string RegionalManagerName { get; set; }

        /// <summary>
        /// 大区经理员工编号
        /// </summary>
        
        public string RegionalManagerNo { get; set; }

        /// <summary>
        /// 是否已到期
        /// </summary>
        
        public bool IsExpire { get; set; }

        /// <summary>
        /// 应还款期数
        /// </summary>
        
        public int? RepaymentPeriod { get; set; }

        /// <summary>
        /// 累计已还期数
        /// </summary>
        
        public int? CumulativeReturnPeriod { get; set; }

        /// <summary>
        /// 累计已还金额
        /// </summary>
        
        public decimal? AccumulatedAmount { get; set; }

        /// <summary>
        /// 剩余期数--期数-【累计已还款期数】	
        /// </summary>
        
        public int? RemainingPeriod { get; set; }

        /// <summary>
        /// 剩余应还本金--合同金额/期数*【剩余期数】
        /// </summary>
        
        public decimal? SurplusPrincipal { get; set; }

        /// <summary>
        /// 提前还款违约金--IF(VALUE(应还款期数)<VALUE(期数),ROUND(IFERROR(IF(FIND("期",借款类型),IF(应还款期数<=3,合同金额*0.05,IF(AND(应还款期数>3,应还款期数<=期数/2),合同金额*0.03,合同金额*0.02))),IF(应还款期数<=3,合同金额*0.05,IF(AND(应还款期数>3,应还款期数<=期数/2),合同金额*0.03,合同金额*0.02))),2),0)
        /// </summary>
        
        public decimal? PrepaymentPenalty { get; set; }

        /// <summary>
        /// 提前还款金额--IF(剩余期数=0,0,IF(OR(剩余期数=1,剩余期数=0),IF(借款类型="押车6期",月利+剩余应还本金,IF(OR(借款类型="GPS6期",借款类型="GPS12期"),剩余应还本金+月利+流量费-保证金,IF(OR(借款类型="GPS30",借款类型="GPS60",借款类型="GPS90"),合同金额+月利+流量费-保证金,合同金额+月利))),IF(借款类型="押车6期",月利+剩余应还本金+提前还款违约金,IF(OR(借款类型="GPS6期",借款类型="GPS12期"),剩余应还本金+提前还款违约金+月利+流量费-保证金,IF(OR(借款类型="GPS30",借款类型="GPS60",借款类型="GPS90"),合同金额+月利+流量费-保证金,合同金额+月利)))))
        /// </summary>
        
        public decimal? PrepaymentAmount { get; set; }

        /// <summary>
        /// 是否已提前一次性还款
        /// </summary>
        
        public bool IsPrepayment { get; set; }

        /// <summary>
        /// 业务状态
        /// </summary>
        
        public int? BusinessStatus { get; set; }

        /// <summary>
        /// 是否确认收费
        /// </summary>
        
        public bool IsChargesApproved { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        
        public string Remarks { get; set; }

        /// <summary>
        /// 上日报日期
        /// </summary>
        
        public string DateOfLastJournalStr { get; set; }
    }
}
