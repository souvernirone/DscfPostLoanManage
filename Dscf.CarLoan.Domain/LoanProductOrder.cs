using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    public class LoanProductOrder
    {
        /// <summary>
        /// ProductOrderId
        /// </summary>
        public int ProductOrderId { get; set; }

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
        /// 申请贷款额
        /// </summary>
        public decimal? ApplyAmount { get; set; }

        /// <summary>
        /// 申请贷款期数
        /// </summary>
        public int? ApplyTerm { get; set; }

        /// <summary>
        /// 可接受的月还款额
        /// </summary>
        public string MonthAmount { get; set; }

        /// <summary>
        /// 审批总额
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// 到手额
        /// </summary>
        public decimal? NetAmount { get; set; }

        /// <summary>
        /// 确定贷款期数
        /// </summary>
        public int? Term { get; set; }

        /// <summary>
        /// 年利率
        /// </summary>
        public decimal? YearRate { get; set; }

        /// <summary>
        /// 每月还本息(月还款额)
        /// </summary>
        public decimal? RepayPerMonth { get; set; }

        /// <summary>
        /// StatusId
        /// </summary>
        public int? StatusId { get; set; }

        /// <summary>
        /// 团队经理
        /// </summary>
        public int? TeamManager { get; set; }

        /// <summary>
        /// 客户经理
        /// </summary>
        public int? CustomerManager { get; set; }

        /// <summary>
        /// 合同开始日期
        /// </summary>
        public DateTime? ContractStartDate { get; set; }

        /// <summary>
        /// 合同结束日期
        /// </summary>
        public DateTime? ContractEndDate { get; set; }

        /// <summary>
        /// 计划签约日期
        /// </summary>
        public DateTime? SignDate { get; set; }

        /// <summary>
        /// 讲解人
        /// </summary>
        public int? Narrator { get; set; }

        /// <summary>
        /// 扣款日
        /// </summary>
        public int? DeductDate { get; set; }

        /// <summary>
        /// 是否联名借款
        /// </summary>
        public bool? IsCoborrowLoan { get; set; }

        /// <summary>
        /// 共同借款人姓名
        /// </summary>
        public string CoborrowName { get; set; }

        /// <summary>
        /// 是否同步外部平台
        /// </summary>
        public bool? IsOpen { get; set; }

        /// <summary>
        /// 外部平台是否同步成功
        /// </summary>
        public bool? IsSyncSuccess { get; set; }

        /// <summary>
        /// 合同文件
        /// </summary>
        public int? AgreementId { get; set; }

        /// <summary>
        /// 待初审人员Id
        /// </summary>
        public int? FirstVerifyOptId { get; set; }

        /// <summary>
        /// 待终审人员Id
        /// </summary>
        public int? LastVerifyOptId { get; set; }

        /// <summary>
        /// 待综评人员Id
        /// </summary>
        public int? TotalReviewOptId { get; set; }

        /// <summary>
        /// 待复议人员Id
        /// </summary>
        public int? ReconsiderOptId { get; set; }

        /// <summary>
        /// IsAuthorization
        /// </summary>
        public int? IsAuthorization { get; set; }

        /// <summary>
        /// TransactionId
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Ditratings
        /// </summary>
        public int? Ditratings { get; set; }

        /// <summary>
        /// 车贷大堂编号
        /// </summary>
        public int? LobbyId { get; set; }

        /// <summary>
        /// 是否是展期
        /// </summary>
        public int? IsExtension { get; set; }

        /// <summary>
        /// CoborrowCaId
        /// </summary>
        public string CoborrowCaId { get; set; }

        /// <summary>
        /// CoborrowTransactionId
        /// </summary>
        public string CoborrowTransactionId { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

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
        /// IsEnable
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// ReconsiderationStatusId
        /// </summary>
        public int? ReconsiderationStatusId { get; set; }

        /// <summary>
        /// CarId
        /// </summary>
        public int? CarId { get; set; }

        /// <summary>
        /// UserBankInfoId
        /// </summary>
        public int? UserBankInfoId { get; set; }

        /// <summary>
        /// 催收人
        /// </summary>
        public int? DeptOptId { get; set; }

        /// <summary>
        /// 催收状态
        /// </summary>
        public int? CollectStatus { get; set; }
        /// <summary>
        /// 导航属性-大堂信息
        /// </summary>
        public virtual LobbyInfo LobbyInfo { get; set; }

        /// <summary>
        /// 导航属性-用户信息
        /// </summary>
        public virtual UserInfo UserInfo { get; set; }

        /// <summary>
        /// 导航属性-借款订单月还列表
        /// </summary>
        public virtual IList<LoanMonthRepay> LoanMonthRepayList { get; set; }

        /// <summary>
        /// 导航属性-借款订单合同列表
        /// </summary>
        public virtual IList<ContractFormation> ContractFormationList { get; set; }

        /// <summary>
        /// 导航属性-查询划扣信息列表
        /// </summary>
        public virtual IList<DeductProgress> DeductProgressList { get; set; }
    }
}
