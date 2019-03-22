using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    [DataContract]
    public class CreditOverdueSearchRequest
    {
        /// <summary>
        /// 操作员Id
        /// </summary>
        [DataMember]
        public int OptId { get; set; }

        /// <summary>
        /// 1信 2车
        /// </summary>
        [DataMember]
        public int LoanOrderType { get; set; }

        [DataMember]
        public int? DeptId { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [DataMember]
        public string City { get; set; }
        /// <summary>
        /// 新客户1 老客户 0 展期客户2
        /// </summary>
        [DataMember]
        public int? CustomerType { get; set; }


        [DataMember]
        public int? LoanTypeId { get; set; }


        [DataMember]
        public DateTime? RepayDate { get; set; }

        /// <summary>
        /// 状态 已还款 1  还一部分2  逾期0
        /// </summary>
        [DataMember]
        public int? Status { get; set; }

        /// <summary>
        /// 催收成功1  催收失败 0
        /// </summary>
        [DataMember]
        public int? CollectStatus { get; set; }


    }
}
