using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    [DataContract]
    public class DepartmentInfoDto
    {
        /// <summary>
        /// DepartmentId
        /// </summary>
        [DataMember]
        public int DepId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [DataMember]
        public string DepName { get; set; }

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
