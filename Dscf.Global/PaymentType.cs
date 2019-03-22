using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Global
{

    /// <summary>
    /// 选择第三方支付类型
    /// </summary>
    [Serializable, DataContract]
    public enum PaymentType
    {

        /// <summary>
        /// 银联支付
        /// </summary>
        [EnumMember]
        Unionpay,

        /// <summary>
        /// 中金支付
        /// </summary>
        [EnumMember]
        ChinaPay,

        /// <summary>
        /// 银生宝支付
        /// </summary>
        [EnumMember]
        UnspayYSBPay,
    }
}
