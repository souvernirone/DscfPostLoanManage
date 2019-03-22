using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Global
{
    /// <summary>
    /// 银联返回的结果
    /// </summary>
    [Serializable, DataContract]
    [KnownType("GetSubTypes")]

    public class UnionpayResultModel
    {
        /// <summary>
        /// 代码
        /// </summary>
        [DataMember]
        public string RET_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        public string SN
        {
            get;
            set;
        }

        /// <summary>
        /// 消息
        /// </summary>
        [DataMember]
        public string ERR_MSG
        {
            get;
            set;
        }

        /// <summary>
        /// 响应码（银生宝）
        /// </summary>
        [DataMember]
        public string Result_code { get; set; }

        /// <summary>
        /// 返回信息（银生宝）
        /// </summary>
        [DataMember]
        public string Result_msg { get; set; }

        /// <summary>
        /// 交易状态（银生宝）
        /// </summary>
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        /// 交易结果描述（银生宝）
        /// </summary>
        [DataMember]
        public string Desc { get; set; }

        /// <summary>
        /// 子协议编号
        /// </summary>
        [DataMember]
        public string SubContractId { get; set; }

    }
}
