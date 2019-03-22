using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.Model
{
    public class LoanSearchViewModel
    {
        /// <summary>
        /// 操作员Id
        /// </summary>
        public int OptId { get; set; }

        /// <summary>
        /// 订单Id
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名：")]
        public string Name { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        [DisplayName("合同号：")]
        public string ContractNo { get; set; }


        /// <summary>
        /// 身份证号
        /// </summary>
        [DisplayName("身份证号：")]
        public string IdCard { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        [DisplayName("订单类型：")]
        public string OrderType { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [DisplayName("城市：")]
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [DisplayName("产品类型：")]
        public string ProductName { get; set; }

        /// <summary>
        /// 签约日期
        /// </summary>
        [DisplayName("签约日期：")]
        public string SignTimeFrom { get; set; }

        /// <summary>
        /// 签约日期
        /// </summary>
        [DisplayName("签约日期：")]
        public string SignTimeTo { get; set; }


        public int PageNum { get; set; }

        public int PageSize { get; set; }
    }
}
