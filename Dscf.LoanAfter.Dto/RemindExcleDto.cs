using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dto
{
    [DataContract]
    public class RemindExcleDto
    {
        /// <summary>
        /// 催收人
        /// </summary>
        [DataMember]
        public string PersonName { get; set; }

        /// <summary>
        /// 借款人
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        [DataMember]
        public string SignCity { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [DataMember]
        public string UserPhone { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 催收时间
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 提醒结果
        /// </summary>
        [DataMember]
        public string RemindText { get; set; }

        /// <summary>
        /// 提醒日志
        /// </summary>
        [DataMember]
        public string RemindContent { get; set; }
    }
}
