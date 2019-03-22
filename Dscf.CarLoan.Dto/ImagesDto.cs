/*******************************************************
*类名称：ImagesDto
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 16:32:03
*说明：
*更新备注：
**********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    [DataContract]
    public class ImagesDto
    {
        /// <summary>
        /// ImgId
        /// </summary>
        [DataMember]
        public int ImgId { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        [DataMember]
        public string ImgPath { get; set; }

        /// <summary>
        /// 缩略图路径
        /// </summary>
        [DataMember]
        public string ThumPath { get; set; }

        /// <summary>
        /// 扩展名
        /// </summary>
        [DataMember]
        public string ImgFixd { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string ImgName { get; set; }

        /// <summary>
        /// 当前ID
        /// </summary>
        [DataMember]
        public int? CurrentId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
        public int? ImgType { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        [DataMember]
        public int? OperateId { get; set; }

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
        /// IsEnable
        /// </summary>
        [DataMember]
        public int? IsEnable { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        [DataMember]
        public int? IsDelete { get; set; }
    }
}
