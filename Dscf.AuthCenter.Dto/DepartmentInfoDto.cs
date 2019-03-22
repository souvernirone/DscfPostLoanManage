using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Dto
{
    [DataContract]
    public class DepartmentInfoDto
    {
        /// <summary>
        /// DepartmentId
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [DataMember]
        public string DeptName { get; set; }

        /// <summary>
        /// 签约地址
        /// </summary>
        [DataMember]
        public string SignAddress { get; set; }

        /// <summary>
        /// 签约城市
        /// </summary>
        [DataMember]
        public string SignCity { get; set; }
    }
}
