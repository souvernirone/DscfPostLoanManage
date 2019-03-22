using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    [DataContract]
    public class LoanSearchViewModel
    {
        /// <summary>
        /// 操作员Id
        /// </summary>
        [DataMember]
        public int OptId { get; set; }

        /// <summary>
        /// OrderId
        /// </summary>
        [DataMember]
        public string OrderId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        [DataMember]
        public string ContractNo { get; set; }


        /// <summary>
        /// 身份证号
        /// </summary>
        [DataMember]
        public string IdCard { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        [DataMember]
        public string OrderType { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [DataMember]
        public string UserPhone { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 签约日期
        /// </summary>
        [DataMember]
        public string SignTimeFrom { get; set; }

        /// <summary>
        /// 签约日期
        /// </summary>
        [DataMember]
        public string SignTimeTo { get; set; }

        [DataMember]
        public int PageNum { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public int[] DeptIds { get; set; }

    }
}
