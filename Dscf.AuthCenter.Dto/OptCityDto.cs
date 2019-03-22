using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Dto
{
    /// <summary>
    /// 
    /// </summary>
     [DataContract]
    public class OptCityDto
    {
        /// <summary>
        /// 操作员主键
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 角色ID列表
        /// </summary>
        [DataMember]
        public IList<int?> SupportDeptList { get; set; }
    }
}
