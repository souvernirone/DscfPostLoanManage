using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Domain
{
    public class FileEntity
    {

        /// <summary>
        /// FileId
        /// </summary>
        public int FileId { get; set; }

        /// <summary>
        /// FileName
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// FileSuffix
        /// </summary>
        public string FileSuffix { get; set; }

        /// <summary>
        /// FilePath
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// FileSize
        /// </summary>
        public int? FileSize { get; set; }

        /// <summary>
        /// ThumbPath
        /// </summary>
        public string ThumbPath { get; set; }

        /// <summary>
        /// SaveFileName
        /// </summary>
        public string SaveFileName { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public bool IsEnable { get; set; }

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
        /// Remark
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }


    }
}
