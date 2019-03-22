using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    [DataContract]
    public class CreditFinancialExportExcleRequest
    {
        /// <summary>
        /// 城市名称
        /// </summary>
        [DataMember]
        public int? ProductType { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [DataMember]
        public int? CityName { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [DataMember]
        public int? ProductName { get; set; }

        /// <summary>
        /// 合同签署开始日期
        /// </summary>
        [DataMember]
        public DateTime? ContractDataBegin { get; set; }

        /// <summary>
        /// 合同签署结束日期
        /// </summary>
        [DataMember]
        public DateTime? ContractDataEnd { get; set; }

        /// <summary>
        /// 放款时间开始
        /// </summary>
        [DataMember]
        public DateTime? LoansDataBegin { get; set; }

        /// <summary>
        /// 放款时间结束
        /// </summary>
        [DataMember]
        public DateTime? LoansDataEnd { get; set; }

        /// <summary>
        /// 所属团队
        /// </summary>
        [DataMember]
        public int? TeamName { get; set; }
    }
}
