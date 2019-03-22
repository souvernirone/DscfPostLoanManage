using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
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
        /// 用户编号
        /// </summary>
        [DataMember]
        public int UserId { get; set; }
    }
}
