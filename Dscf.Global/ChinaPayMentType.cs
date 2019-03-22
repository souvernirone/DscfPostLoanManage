using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Global
{

    /// <summary>
    /// 中金支付操作类型
    /// </summary>
    [Serializable, DataContract]
    public enum ChinaPayMentType
    {
        /// <summary>
        /// 划付
        /// </summary>
        [EnumMember]
        CollectType,

        /// <summary>
        /// 划扣
        /// </summary>
        [EnumMember]
        DeductType,

        /// <summary>
        /// 划付查询
        /// </summary>
        [EnumMember]
        CollectQueryType,


        /// <summary>
        /// 划扣查询
        /// </summary>
        [EnumMember]
        DeductQueryType,

        /// <summary>
        /// 子协议查询
        /// </summary>
        [EnumMember]
        SubContractIdQuery,

        /// <summary>
        /// 子协议录入
        /// </summary>
        [EnumMember]
        SubContractSignSimple,
        
        /// <summary>
        /// 商户账号余额查询
        /// </summary>
        [EnumMember]
        QueryBlancePay,
        
        /// <summary>
        /// 子协议延期
        /// </summary>
        [EnumMember]
        SubConstractExtension,

    }
}
