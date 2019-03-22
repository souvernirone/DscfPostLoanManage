/*******************************************************
*类名称：ExtraInfo
*版本号：V1.0.0.0
*作者：Administrator
*CLR版本：4.0.30319.36264
*创建时间：2017/4/1 10:54:46
*说明：
*更新备注：
**********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Domain
{
    public class ExtraInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// OrderId
        /// </summary>
        public int? OrderId { get; set; }

        /// <summary>
        /// OrderType
        /// </summary>
        public int? OrderType { get; set; }

        /// <summary>
        /// ExtraContent
        /// </summary>
        public string ExtraContent { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public bool? IsEnable { get; set; }

        /// <summary>
        /// CreateOptId
        /// </summary>
        public int? CreateOptId { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }


    }
}
