using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dto
{
    [DataContract]
    public class CollectionInfoDto
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
        /// CollectionStatus
        /// </summary>
        [DataMember]
        public int? CollectionStatus { get; set; }

        /// <summary>
        /// CollectionStatusName
        /// </summary>
        [DataMember]
        public string CollectionStatusName { get; set; }

        /// <summary>
        /// OutboundAddress
        /// </summary>
        [DataMember]
        public string OutboundAddress { get; set; }

        /// <summary>
        /// LinkPersonTypeName
        /// </summary>
        [DataMember]
        public string LinkPersonTypeName { get; set; }
        /// <summary>
        /// LinkPersonType
        /// </summary>
        [DataMember]
        public int? LinkPersonType { get; set; }

        /// <summary>
        /// CollectionRecord
        /// </summary>
        [DataMember]
        public string CollectionRecord { get; set; }

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
        /// OptName
        /// </summary>
        [DataMember]
        public string OptName { get; set; }

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
        /// 上传资料列表
        /// </summary>
        [DataMember]
        public IList<FileEntityDto> UpFileList { get; set; }
    }
}
