/*******************************************************
*类名称：LoanOrderDto
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 14:50:18
*说明：
*更新备注：
**********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    [DataContract]
    public class LoanOrderDto
    {
        /// <summary>
        /// ProductOrderId
        /// </summary>
        [DataMember]
        public int ProductOrderId { get; set; }

        /// <summary>
        /// ProductTypeId
        /// </summary>
         [DataMember]
        public int? ProductTypeId { get; set; }

        /// <summary>
        /// Purpose
        /// </summary>
         [DataMember]
         public string Purpose { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
         [DataMember]
         public int? UserId { get; set; }

        /// <summary>
        /// 申请贷款额
        /// </summary>
         [DataMember]
         public decimal? ApplyAmount { get; set; }

        /// <summary>
        /// 申请贷款期数
        /// </summary>
         [DataMember]
         public int? ApplyTerm { get; set; }

        /// <summary>
        /// 可接受的月还款额
        /// </summary>
         [DataMember]
         public string MonthAmount { get; set; }

        /// <summary>
        /// 审批总额
        /// </summary>
         [DataMember]
         public decimal? Amount { get; set; }

        /// <summary>
        /// 到手额
        /// </summary>
         [DataMember]
         public decimal? NetAmount { get; set; }

        /// <summary>
        /// 确定贷款期数
        /// </summary>
         [DataMember]
         public int? Term { get; set; }

        /// <summary>
        /// 年利率
        /// </summary>
         [DataMember]
         public decimal? YearRate { get; set; }

        /// <summary>
        /// 每月还本息(月还款额)
        /// </summary>
         [DataMember]
         public decimal? RepayPerMonth { get; set; }

        /// <summary>
        /// StatusId
        /// </summary>
         [DataMember]
         public int? StatusId { get; set; }

        /// <summary>
        /// 团队经理
        /// </summary>
         [DataMember]
         public int? TeamManager { get; set; }

        /// <summary>
        /// 客户经理
        /// </summary>
         [DataMember]
         public int? CustomerManager { get; set; }

        /// <summary>
        /// 合同开始日期
        /// </summary>
         [DataMember]
         public DateTime? ContractStartDate { get; set; }

        /// <summary>
        /// 合同结束日期
        /// </summary>
         [DataMember]
         public DateTime? ContractEndDate { get; set; }

        /// <summary>
        /// 计划签约日期
        /// </summary>
         [DataMember]
         public DateTime? SignDate { get; set; }

        /// <summary>
        /// 讲解人
        /// </summary>
         [DataMember]
         public int? Narrator { get; set; }

        /// <summary>
        /// 扣款日
        /// </summary>
         [DataMember]
         public int? DeductDate { get; set; }

        /// <summary>
        /// 是否联名借款
        /// </summary>
         [DataMember]
         public bool? IsCoborrowLoan { get; set; }

        /// <summary>
        /// 共同借款人姓名
        /// </summary>
         [DataMember]
         public string CoborrowName { get; set; }

        /// <summary>
        /// 是否同步外部平台
        /// </summary>
         [DataMember]
         public bool? IsOpen { get; set; }

        /// <summary>
        /// 外部平台是否同步成功
        /// </summary>
         [DataMember]
         public bool? IsSyncSuccess { get; set; }

        /// <summary>
        /// 合同文件
        /// </summary>
         [DataMember]
         public int? AgreementId { get; set; }

        /// <summary>
        /// 待初审人员Id
        /// </summary>
         [DataMember]
         public int? FirstVerifyOptId { get; set; }

        /// <summary>
        /// 待终审人员Id
        /// </summary>
         [DataMember]
         public int? LastVerifyOptId { get; set; }

        /// <summary>
        /// 待综评人员Id
        /// </summary>
         [DataMember]
         public int? TotalReviewOptId { get; set; }

        /// <summary>
        /// 待复议人员Id
        /// </summary>
         [DataMember]
         public int? ReconsiderOptId { get; set; }

        /// <summary>
        /// IsAuthorization
        /// </summary>
         [DataMember]
         public int? IsAuthorization { get; set; }

        /// <summary>
        /// TransactionId
        /// </summary>
         [DataMember]
         public string TransactionId { get; set; }

        /// <summary>
        /// Ditratings
        /// </summary>
         [DataMember]
         public int? Ditratings { get; set; }

        /// <summary>
        /// 车贷大堂编号
        /// </summary>
         [DataMember]
         public int? LobbyId { get; set; }

        /// <summary>
        /// 是否是展期
        /// </summary>
         [DataMember]
         public int? IsExtension { get; set; }

        /// <summary>
        /// CoborrowCaId
        /// </summary>
         [DataMember]
         public string CoborrowCaId { get; set; }

        /// <summary>
        /// CoborrowTransactionId
        /// </summary>
         [DataMember]
         public string CoborrowTransactionId { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
         [DataMember]
         public DateTime? CreateTime { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
         [DataMember]
         public int? OperateId { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
         [DataMember]
         public int? LastOperateId { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
         [DataMember]
         public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
         [DataMember]
         public int? IsEnable { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
         [DataMember]
         public int? IsDelete { get; set; }

        /// <summary>
        /// ReconsiderationStatusId
        /// </summary>
         [DataMember]
         public int? ReconsiderationStatusId { get; set; }

        /// <summary>
        /// CarId
        /// </summary>
         [DataMember]
         public int? CarId { get; set; }

        /// <summary>
        /// UserBankInfoId
        /// </summary>
         [DataMember]
         public int? UserBankInfoId { get; set; }
    }
}
