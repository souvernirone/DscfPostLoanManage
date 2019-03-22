using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Domain
{
    /// <summary>
    /// 催收信息记录
    /// </summary>
    public class CollectionInfo
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
        /// CollectionStatus
        /// </summary>
        public int? CollectionStatus { get; set; }

        /// <summary>
        /// OutboundAddress
        /// </summary>
        public string OutboundAddress { get; set; }

        /// <summary>
        /// LinkPersonType
        /// </summary>
        public int? LinkPersonType { get; set; }

        /// <summary>
        /// CollectionRecord
        /// </summary>
        public string CollectionRecord { get; set; }

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

        /// <summary>
        /// 上传资料列表
        /// </summary>
        public IList<FileEntity> UpFileList { get; set; }


    }
}
