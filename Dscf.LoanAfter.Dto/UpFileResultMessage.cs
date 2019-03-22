using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dto
{
    [MessageContract]
    public class UpFileResultMessage
    {
        /// <summary>
        /// 文件保存是否成功
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public string Message { get; set; }

        /// <summary>
        /// 原始文件名-（无扩展名）
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public string FileName { get; set; }

        /// <summary>
        /// 文件名扩展名
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public string FileSuffix { get; set; }

        /// <summary>
        /// 文件名保存路径
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public string FilePath { get; set; }

        /// <summary>
        /// 文件类型为图片时
        /// 缩略图保存路径
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public string ThumbPath { get; set; }

        /// <summary>
        /// 保存文件名（无扩展名）
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public string SaveFileName { get; set; }
    }
}
