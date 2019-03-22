using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    //合同信息
    [DataContract]
    public class ContractFormationDto
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>
        [DataMember]
        public string ContractName { get; set; }

        /// <summary>
        /// 合同类别 parentid
        /// </summary>
        [DataMember]
        public int? ContractType { get; set; }

        /// <summary>
        /// 借款协议id
        /// </summary>
        [DataMember]
        public int? CreditListId { get; set; }

        /// <summary>
        /// 合同小类别（对应字典表）value
        /// </summary>
        [DataMember]
        public int? TypeCode { get; set; }

        /// <summary>
        /// 合同路径
        /// </summary>
        [DataMember]
        public string ContractPath { get; set; }

        /// <summary>
        /// 合同时间
        /// </summary>
        [DataMember]
        public DateTime? ContractTime { get; set; }

        /// <summary>
        /// 借款订单id
        /// </summary>
        [DataMember]
        public int? LoanOrderId { get; set; }

        /// <summary>
        /// 理财订单id
        /// </summary>
        [DataMember]
        public int? FinancingOrderId { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public int? ContractOperator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 是否签章,默认为0，签章后为1
        /// </summary>
        [DataMember]
        public int? IsSignature { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [DataMember]
        public string ContratctNumber { get; set; }

        /// <summary>
        /// 展期id
        /// </summary>
        [DataMember]
        public int? ExtensionId { get; set; }

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
        /// LastUpdateTime
        /// </summary>
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }

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
        /// 原名称
        /// </summary>
        [DataMember]
        public string StartName { get; set; }
    }
}
