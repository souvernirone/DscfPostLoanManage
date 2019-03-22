using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain
{
    //贷款信贷产品订单表
    public class LoanProductOrder
    {
        /// <summary>
        /// OrderId
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// ProductTypeId
        /// </summary>
        public int? ProductTypeId { get; set; }

        /// <summary>
        /// Purpose
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// RelateProductId
        /// </summary>
        public string RelateProductId { get; set; }

        /// <summary>
        /// ApplyAmount
        /// </summary>
        public string ApplyAmount { get; set; }

        /// <summary>
        /// ApplyTerm
        /// </summary>
        public string ApplyTerm { get; set; }

        /// <summary>
        /// MonthAmount
        /// </summary>
        public string MonthAmount { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// NetAmount
        /// </summary>
        public decimal? NetAmount { get; set; }

        /// <summary>
        /// Term
        /// </summary>
        public int? Term { get; set; }

        /// <summary>
        /// YearRate
        /// </summary>
        public decimal? YearRate { get; set; }

        /// <summary>
        /// RepayPerMonth
        /// </summary>
        public decimal? RepayPerMonth { get; set; }

        /// <summary>
        /// RepayPeriod
        /// </summary>
        public int? RepayPeriod { get; set; }

        /// <summary>
        /// ValiTerm
        /// </summary>
        public int? ValiTerm { get; set; }

        /// <summary>
        /// FeePerMonth
        /// </summary>
        public decimal? FeePerMonth { get; set; }

        /// <summary>
        /// ServerFee
        /// </summary>
        public decimal? ServerFee { get; set; }

        /// <summary>
        /// Memo
        /// </summary>
        public int? Memo { get; set; }

        /// <summary>
        /// RepayWayId
        /// </summary>
        public int? RepayWayId { get; set; }

        /// <summary>
        /// VerifyStatus
        /// </summary>
        public int? VerifyStatus { get; set; }

        /// <summary>
        /// CreateUserId
        /// </summary>
        public int? CreateUserId { get; set; }

        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// TeamManager
        /// </summary>
        public int? TeamManager { get; set; }

        /// <summary>
        /// CustomerManager
        /// </summary>
        public int? CustomerManager { get; set; }

        /// <summary>
        /// ContractStartDate
        /// </summary>
        public DateTime? ContractStartDate { get; set; }

        /// <summary>
        /// ContractEndDate
        /// </summary>
        public DateTime? ContractEndDate { get; set; }

        /// <summary>
        /// SignDate
        /// </summary>
        public DateTime? SignDate { get; set; }

        /// <summary>
        /// DeductBankName
        /// </summary>
        public string DeductBankName { get; set; }

        /// <summary>
        /// DeductBranchBank
        /// </summary>
        public string DeductBranchBank { get; set; }

        /// <summary>
        /// DeductBankAccount
        /// </summary>
        public string DeductBankAccount { get; set; }

        /// <summary>
        /// Narrator
        /// </summary>
        public int? Narrator { get; set; }

        /// <summary>
        /// DeductDate
        /// </summary>
        public int? DeductDate { get; set; }

        /// <summary>
        /// IsCoborrowLoan
        /// </summary>
        public bool? IsCoborrowLoan { get; set; }

        /// <summary>
        /// CoborrowName
        /// </summary>
        public string CoborrowName { get; set; }

        /// <summary>
        /// CoborrowIDCard
        /// </summary>
        public string CoborrowIDCard { get; set; }

        /// <summary>
        /// CoborrowAddress
        /// </summary>
        public string CoborrowAddress { get; set; }

        /// <summary>
        /// IsOpen
        /// </summary>
        public bool? IsOpen { get; set; }

        /// <summary>
        /// AgreementId
        /// </summary>
        public int? AgreementId { get; set; }

        /// <summary>
        /// FirstVerifyOptId
        /// </summary>
        public int? FirstVerifyOptId { get; set; }

        /// <summary>
        /// LastVerifyOptId
        /// </summary>
        public int? LastVerifyOptId { get; set; }

        /// <summary>
        /// TotalReviewOptId
        /// </summary>
        public int? TotalReviewOptId { get; set; }

        /// <summary>
        /// ReconsiderOptId
        /// </summary>
        public int? ReconsiderOptId { get; set; }

        /// <summary>
        /// IsAccordanceProduct
        /// </summary>
        public bool? IsAccordanceProduct { get; set; }

        /// <summary>
        /// ChangeProductName
        /// </summary>
        public string ChangeProductName { get; set; }

        /// <summary>
        /// IsSyncSuccess
        /// </summary>
        public bool? IsSyncSuccess { get; set; }

        /// <summary>
        /// HasMatchAmount
        /// </summary>
        public decimal? HasMatchAmount { get; set; }

        /// <summary>
        /// RemainMatchAmount
        /// </summary>
        public decimal? RemainMatchAmount { get; set; }

        /// <summary>
        /// 是否放款  0:未放款，1:放款成功，2:放款失败，3:结果等待中
        /// </summary>
        public int? IsLoan { get; set; }

        /// <summary>
        /// DDFinancialID
        /// </summary>
        public int? DDFinancialID { get; set; }

        /// <summary>
        /// 对应大地金融借款订单ID
        /// </summary>
        public int? DdLoanOrderId { get; set; }

        /// <summary>
        /// 押车种类 1：GPS  2：押车
        /// </summary>
        public int? RiderType { get; set; }

        /// <summary>
        /// 推荐分期
        /// </summary>
        public int? RecinStallment { get; set; }

        /// <summary>
        /// 评分决策：
        /// </summary>
        public string Resultdecision { get; set; }

        /// <summary>
        /// 批贷限额
        /// </summary>
        public decimal? MaxLoan { get; set; }

        /// <summary>
        /// 贷前负债率：
        /// </summary>
        public int? LoanBeforeRatio { get; set; }

        /// <summary>
        /// 贷后负债率
        /// </summary>
        public int? LoanAfterRatio { get; set; }

        /// <summary>
        /// IsAuthorization
        /// </summary>
        public int? IsAuthorization { get; set; }

        /// <summary>
        /// TransactionId
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// IsContractCreate
        /// </summary>
        public int? IsContractCreate { get; set; }

        /// <summary>
        /// CoborrowCaId
        /// </summary>
        public string CoborrowCaId { get; set; }

        /// <summary>
        /// CarLoanId
        /// </summary>
        public int? CarLoanId { get; set; }

        /// <summary>
        /// IsExtension
        /// </summary>
        public bool? IsExtension { get; set; }

        /// <summary>
        /// LicensePlate
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Ditratings
        /// </summary>
        public int? Ditratings { get; set; }

        /// <summary>
        /// CoborrowTransactionId
        /// </summary>
        public string CoborrowTransactionId { get; set; }

        /// <summary>
        /// IsAgencyContract
        /// </summary>
        public int? IsAgencyContract { get; set; }

        /// <summary>
        /// DeptOptId
        /// </summary>
        public int? DeptOptId { get; set; }

        /// <summary>
        /// 催收状态
        /// </summary>
        public int? CollectStatus { get; set; }

        /// <summary>
        /// OrganizationId
        /// </summary>
        public int? OrganizationId { get; set; }

        /// <summary>
        /// 导航属性-用户信息
        /// </summary>
        public virtual UserInfo UserInfo { get; set; }

        /// <summary>
        /// 导航属性-操作员信息
        /// </summary>
        public virtual OperaterInfo OperaterInfo { get; set; }

        /// <summary>
        /// 导航属性-借款订单月还列表
        /// </summary>
        public virtual IList<Loan_MonthRepay> LoanMonthRepayList { get; set; }
    }
}
