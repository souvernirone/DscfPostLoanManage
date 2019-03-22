/*******************************************************
*类名称：ExtraInfoDto
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/1 11:06:35
*说明：数据契约-贷后系统新增信息
*更新备注：
**********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dto
{
    [DataContract]
    public class ExtraInfoDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// OrderId
        /// </summary>
        [DataMember]
        public int? OrderId { get; set; }

        /// <summary>
        /// OrderType
        /// </summary>
        [DataMember]
        public int? OrderType { get; set; }

        /// <summary>
        /// 新增内容
        /// </summary>
        [DataMember]
        public string ExtraContent { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>
        [DataMember]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        [DataMember]
        public bool? IsEnable { get; set; }

        /// <summary>
        /// CreateOptId
        /// </summary>
        [DataMember]
        public int? CreateOptId { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        [DataMember]
        public int? LastOperateId { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 创建操作员名字
        /// </summary>
        [DataMember]
        public string CreateOptName { get; set; }

    }
}
