﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Settlement.Model
{
    public class CreditOverdueExcelViewModel
    {
        /// <summary>
        /// 还款标识
        /// </summary>
        public string RepayIdentification { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public string SignCity { get; set; }
        /// <summary>
        /// 划扣日期
        /// </summary>
        public DateTime? RepayDate { get; set; }
        /// <summary>
        /// 账单日
        /// </summary>
        public int? RepayDay { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        public string Contract { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCard { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        public string DeductBranchBank { get; set; }
        /// <summary>
        /// 开户行代码
        /// </summary>
        public string SubBranchCode { get; set; }
        /// <summary>
        /// 划扣账号
        /// </summary>
        public string DeductBankAccount { get; set; }
        /// <summary>
        /// 期数
        /// </summary>
        public int? ToalPeriod { get; set; }
        /// <summary>
        /// 已还期数
        /// </summary>
        public int? IsDeductTerm { get; set; }
        /// <summary>
        /// 首还日期
        /// </summary>
        public DateTime? FirstRepaymentDate { get; set; }
        /// <summary>
        /// 借款日期
        /// </summary>
        public DateTime? SignDate { get; set; }
        /// <summary>
        /// 逾期情况
        /// </summary>
        public string OverdueCondition { get; set; }

        /// <summary>
        /// 客户经理
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 信审
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// 合同额
        /// </summary>
        public decimal? Amount { get; set; }
        /// <summary>
        /// 月还款额
        /// </summary>
        public decimal? MonthRepay { get; set; }
        /// <summary>
        /// 月还本金
        /// </summary>
        public decimal? MonthRepayPrincipal { get; set; }
        /// <summary>
        /// 月还利息
        /// </summary>
        public decimal? MonthProfit { get; set; }
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
        /// 应还款总额
        /// </summary>
        public decimal? TermTotal { get; set; }

        /// <summary>
        /// 减免金额
        /// </summary>
        public decimal? DeductMoney { get; set; }
        /// <summary>
        /// 实际还款日期
        /// </summary>

        public DateTime? ActualDeductDate { get; set; }
        /// <summary>
        /// 实际还款金额
        /// </summary>
        public decimal? ActualDeductAmount { get; set; }
        /// <summary>
        /// 还款方式
        /// </summary>
        public string PayWayName { get; set; }
        /// <summary>
        /// 实时逾期金额
        /// </summary>
        public decimal? TotalShouldRepaid { get; set; }
        /// <summary>
        /// 公式上所在期数
        /// </summary>
        public int? PeriodOrder { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string UserPhone { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// 首还客户
        /// </summary>
        public string FirstCustomer { get; set; }
        /// <summary>
        /// 确认日期
        /// </summary>
        public DateTime? ConfirmDate { get; set; }
        /// <summary>
        /// 当天还款额
        /// </summary>
        public decimal? DayRepay { get; set; }

    }
}