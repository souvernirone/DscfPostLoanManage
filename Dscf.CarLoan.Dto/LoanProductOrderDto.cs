using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    [DataContract]
    public class LoanProductOrderDto
    {
        /// <summary>
        /// 订单编号
        /// </summary>        
        [DataMember]
        public int OrderId { get; set; }

        /// <summary>
        /// 签署地
        /// </summary>
        [DataMember]
        public string SignCity { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [DataMember]
        public string IDCard { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [DataMember]
        public string Contract { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        [DataMember]
        public decimal? Amount { get; set; }

        /// <summary>
        /// 签约日期
        /// </summary>
        [DataMember]
        public DateTime? SignDate { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [DataMember]
        public string BankName { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [DataMember]
        public string BankCard { get; set; }

        /// <summary>
        /// 银行支行名称
        /// </summary>
        [DataMember]
        public string SubBranchName { get; set; }

        /// <summary>
        /// 订单类型【1信贷,2车贷】
        /// </summary>
        [DataMember]
        public int OrderType { get; set; }

        /// <summary>
        /// 审批期限
        /// </summary>
        [DataMember]
        public int Term { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }

        /// <summary>
        /// 公司联系电话
        /// </summary>
        [DataMember]
        public string CompanyTel { get; set; }

        /// <summary>
        /// 证明人姓名
        /// </summary>
        [DataMember]
        public string CertifyName { get; set; }

        /// <summary>
        /// 证明人关系
        /// </summary>
        [DataMember]
        public string CertifyRelation { get; set; }

        /// <summary>
        /// 证明人电话
        /// </summary>
        [DataMember]
        public string CertifyTel { get; set; }

        /// <summary>
        /// 证明人姓名2
        /// </summary>
        [DataMember]
        public string CertifyName2 { get; set; }

        /// <summary>
        /// 证明人关系2
        /// </summary>
        [DataMember]
        public string CertifyRelation2 { get; set; }

        /// <summary>
        /// 证明人电话2
        /// </summary>
        [DataMember]
        public string CertifyTel2 { get; set; }

        /// <summary>
        /// T_Lobby.LoanExtensionId
        /// </summary>
        [DataMember]
        public int? LobbyLoanExtensionId { get; set; }

        /// <summary>
        /// 催收状态
        /// </summary>
        [DataMember]
        public int? CollectStatus { get; set; }

        /// <summary>
        /// 大堂KEY
        /// </summary>
        [DataMember]
        public int? LobbyId { get; set; }

        /// <summary>
        /// 借款客户KEY
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

    }
}
