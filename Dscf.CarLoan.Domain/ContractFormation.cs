using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    //合同信息
    public class ContractFormation
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// 合同类别 parentid
        /// </summary>
        public int? ContractType { get; set; }

        /// <summary>
        /// 借款协议id
        /// </summary>
        public int? CreditListId { get; set; }

        /// <summary>
        /// 合同小类别（对应字典表）value
        /// </summary>
        public int? TypeCode { get; set; }

        /// <summary>
        /// 合同路径
        /// </summary>
        public string ContractPath { get; set; }

        /// <summary>
        /// 合同时间
        /// </summary>
        public DateTime? ContractTime { get; set; }

        /// <summary>
        /// 借款订单id
        /// </summary>
        public int? LoanOrderId { get; set; }

        /// <summary>
        /// 理财订单id
        /// </summary>
        public int? FinancingOrderId { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? ContractOperator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 是否签章,默认为0，签章后为1
        /// </summary>
        public int? IsSignature { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContratctNumber { get; set; }

        /// <summary>
        /// 展期id
        /// </summary>
        public int? ExtensionId { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// 原名称
        /// </summary>
        public string StartName { get; set; }
    }
}
