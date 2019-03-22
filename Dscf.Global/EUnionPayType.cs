using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Global
{
    /// <summary>
    /// 提交时的操作类型
    /// 批量划收,批量划付,
    /// </summary>
    [Serializable, DataContract]
    public enum EUnionPayType
    {
        /// <summary>
        /// 划付
        /// </summary>
        [EnumMember]
        CollectType,

        /// <summary>
        /// 划收
        /// </summary>
        [EnumMember]
        DeductType,

        /// <summary>
        /// 月还划收
        /// </summary>
        [EnumMember]
        AutoDeductType,

        /// <summary>
        /// 查询结果
        /// </summary>
        [EnumMember]
        QueryResult,

    }
}
