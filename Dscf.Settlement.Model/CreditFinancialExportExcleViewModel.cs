using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Settlement.Model
{
    public class CreditFinancialExportExcleViewModel
    {
        /// <summary>
        /// 签约城市
        /// </summary>
        public string SignCity { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string Contract { get; set; }

        /// <summary>
        /// 借款订单编号
        /// </summary>
        public int OrderId { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 借款类型
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 借款用途
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// 是否循环贷
        /// </summary>
        public bool? IsRecyclingLoans { get; set; }

        /// <summary>
        /// 划扣银行账户
        /// </summary>
        public string DeductBankAccount { get; set; }
        
        /// <summary>
        /// 划扣银行
        /// </summary>
        public string DeductBankName { get; set; }

        /// <summary>
        /// 划扣银行支行
        /// </summary>
        public string DeductBranchBank { get; set; }
       
        /// <summary>
        /// 签约日期
        /// </summary>
        public string SignDateStr { get; set; }

        /// <summary>
        /// 合同额（签约合同）
        /// </summary>
        public string ApplyAmount { get; set; }

        /// <summary>
        /// 合同额
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// 借款期限批款期
        /// </summary>
        public int? Term { get; set; }

        /// <summary>
        /// 月还金额
        /// </summary>
        public decimal? RepayPerMonth { get; set; }

        /// <summary>
        /// 首次还款日期
        /// </summary>
        public string FirstRepaymentDateStr { get; set; }
        
        /// <summary>
        /// 扣款日/每月还款日
        /// </summary>
        public int? DeductDate { get; set; }

        /// <summary>
        /// 是否联名贷
        /// </summary>
        public bool? IsCoborrowLoan { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 共同借款人姓名
        /// </summary>
        public string CoborrowName { get; set; }

        /// <summary>
        /// 共同借款人身份证号
        /// </summary>
        public string CoborrowIDCard { get; set; }

        /// <summary>
        /// 是否加急
        /// </summary>
        public bool? IsExtension { get; set; }

        /// <summary>
        /// 是否已提前还款
        /// </summary>
        public bool? IsPrepayment { get; set; }

        /// <summary>
        /// 提前还款日期
        /// </summary>
        public string PrepaymentDateStr { get; set; }

        /// <summary>
        /// 一次性还款金额
        /// </summary>
        public decimal? OnetimeRepaymentAmount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 实际放款日期
        /// </summary>
        public string ActualLenderDateStr { get; set; }

        /// <summary>
        /// 客户经理员工编号
        /// </summary>
        public int? CustomerManager { get; set; }

        /// <summary>
        /// 客户经理姓名
        /// </summary>
        public string CustomerManagerName { get; set; }

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
    }
}
