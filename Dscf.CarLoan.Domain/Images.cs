/*******************************************************
*类名称：Images
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 16:25:18
*说明：
*更新备注：
**********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    public class Images
    {

        /// <summary>
        /// ImgId
        /// </summary>
        public int ImgId { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgPath { get; set; }

        /// <summary>
        /// 缩略图路径
        /// </summary>
        public string ThumPath { get; set; }

        /// <summary>
        /// 扩展名
        /// </summary>
        public string ImgFixd { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string ImgName { get; set; }

        /// <summary>
        /// 当前ID
        /// </summary>
        public int? CurrentId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int? ImgType { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        public int? IsDelete { get; set; }


    }
}
