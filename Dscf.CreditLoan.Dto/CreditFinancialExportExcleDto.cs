using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class CreditFinancialExportExcleDto
    {
        /// <summary>
        /// 借款订单编号
        /// </summary>
        [DataMember]
        public int OrderId { get; set; }

        /// <summary>
        /// 签约城市
        /// </summary>
        [DataMember]
        public string SignCity { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [DataMember]
        public string Contract { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [DataMember]
        public string IDCard { get; set; }

        /// <summary>
        /// 借款类型
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 借款用途
        /// </summary>
        [DataMember]
        public string Purpose { get; set; }

        /// <summary>
        /// 是否循环贷
        /// </summary>
        [DataMember]
        public bool? IsRecyclingLoans { get; set; }

        /// <summary>
        /// 划扣银行
        /// </summary>
        [DataMember]
        public string DeductBankName { get; set; }

        /// <summary>
        /// 划扣银行支行
        /// </summary>
        [DataMember]
        public string DeductBranchBank { get; set; }

        /// <summary>
        /// 划扣银行账户
        /// </summary>
        [DataMember]
        public string DeductBankAccount { get; set; }

        /// <summary>
        /// 面签时间
        /// </summary>
        public DateTime? SignDate { get; set; }

        /// <summary>
        /// 面签时间
        /// </summary>
        [DataMember]
        public string SignDateStr { get; set; }

        /// <summary>
        /// 客户信息
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// 合同额（签约合同）
        /// </summary>
        [DataMember]
        public string ApplyAmount { get; set; }

        /// <summary>
        /// 合同额
        /// </summary>
        [DataMember]
        public decimal? Amount { get; set; }

        /// <summary>
        /// 借款期限批款期
        /// </summary>
        [DataMember]
        public int? Term { get; set; }

        /// <summary>
        /// 月还金额
        /// </summary>
        [DataMember]
        public decimal? RepayPerMonth { get; set; }

        /// <summary>
        /// 首次还款日期--IF(OR(VALUE(期数)=12,VALUE(期数)=6),IF(AND(DAY(AL2)>=6,DAY(AL2)<=19),DATE(YEAR(AL2),MONTH(AL2)+1,6),IF(AND(DAY(AL2)>19,DAY(AL2)<=31),DATE(YEAR(AL2),MONTH(AL2)+1,20),DATE(YEAR(AL2),MONTH(AL2),20))),IF(DAY(EOMONTH(DATE(YEAR(AL2),MONTH(AL2)+1,1),0))<DAY(AL2),EOMONTH(DATE(YEAR(AL2),MONTH(AL2)+1,1),0),DATE(YEAR(AL2),MONTH(AL2)+1,DAY(AL2))))
        /// </summary>
        public DateTime? FirstRepaymentDate { get; set; }

        /// <summary>
        /// 首次还款日期
        /// </summary>
        [DataMember]
        public string FirstRepaymentDateStr { get; set; }

        /// <summary>
        /// 扣款日/每月还款日
        /// </summary>
        [DataMember]
        public int? DeductDate { get; set; }

        /// <summary>
        /// 是否联名贷
        /// </summary>
        [DataMember]
        public bool? IsCoborrowLoan { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// 共同借款人姓名
        /// </summary>
        [DataMember]
        public string CoborrowName { get; set; }

        /// <summary>
        /// 共同借款人身份证号
        /// </summary>
        [DataMember]
        public string CoborrowIDCard { get; set; }

        /// <summary>
        /// 是否加急
        /// </summary>
        [DataMember]
        public bool? IsExtension { get; set; }

        /// <summary>
        /// 是否已提前还款
        /// </summary>
        [DataMember]
        public bool? IsPrepayment { get; set; }

        /// <summary>
        /// 提前还款日期
        /// </summary>
        public DateTime? PrepaymentDate { get; set; }

        /// <summary>
        /// 提前还款日期
        /// </summary>
        [DataMember]
        public string PrepaymentDateStr { get; set; }

         /// <summary>
        /// 一次性还款金额
        /// </summary>
        [DataMember]
        public decimal?  OnetimeRepaymentAmount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remarks { get; set; }

        /// <summary>
        /// 实际放款日期
        /// </summary>
        public DateTime? ActualLenderDate { get; set; }

        /// <summary>
        /// 实际放款日期
        /// </summary>
        [DataMember]
        public string ActualLenderDateStr { get; set; }

        /// <summary>
        /// 客户经理员工编号
        /// </summary>
        [DataMember]
        public int? CustomerManager { get; set; }

        /// <summary>
        /// 客户经理姓名
        /// </summary>
        [DataMember]
        public string CustomerManagerName { get; set; }

        /// <summary>
        /// 客户经理联系电话
        /// </summary>
        [DataMember]
        public string CustomerManagerPhone { get; set; }

        /// <summary>
        /// 团队经理ID
        /// </summary>
        [DataMember]
        public int? TeamManager { get; set; }

        /// <summary>
        /// 团队名称
        /// </summary>
        [DataMember]
        public string TeamManagerGroup { get; set; }

        /// <summary>
        /// 团队经理
        /// </summary>
        [DataMember]
        public string TeamManagerName { get; set; }

        /// <summary>
        /// 营业部经理姓名
        /// </summary>
        [DataMember]
        public string SalesManagerName { get; set; }

        /// <summary>
        /// 营业部经理员工编号
        /// </summary>
        [DataMember]
        public string SalesManagerNo { get; set; }

        /// <summary>
        /// 城市经理姓名
        /// </summary>
        [DataMember]
        public string CityManagerName { get; set; }

        /// <summary>
        /// 城市经理员工编号
        /// </summary>
        [DataMember]
        public string CityManagerNo { get; set; }

        /// <summary>
        /// 大区经理姓名
        /// </summary>
        [DataMember]
        public string RegionalManagerName { get; set; }

        /// <summary>
        /// 大区经理员工编号
        /// </summary>
        [DataMember]
        public string RegionalManagerNo { get; set; }

    }
}
