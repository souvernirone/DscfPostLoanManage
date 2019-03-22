using System;
using System.Runtime.Serialization;

namespace Dscf.LoanAfter.Dto
{
    [DataContract]
    public class FileEntityDto
    {

        /// <summary>
        /// FileId
        /// </summary>
        [DataMember]
        public int FileId { get; set; }

        /// <summary>
        /// FileName
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// FileSuffix
        /// </summary>
        [DataMember]
        public string FileSuffix { get; set; }

        /// <summary>
        /// FilePath
        /// </summary>
        [DataMember]
        public string FilePath { get; set; }

        /// <summary>
        /// FileSize
        /// </summary>
        [DataMember]
        public int? FileSize { get; set; }

        /// <summary>
        /// ThumbPath
        /// </summary>
        [DataMember]
        public string ThumbPath { get; set; }

        /// <summary>
        /// SaveFileName
        /// </summary>
        [DataMember]
        public string SaveFileName { get; set; }

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

        [DataMember]
        public string Remark { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }
    }
}
