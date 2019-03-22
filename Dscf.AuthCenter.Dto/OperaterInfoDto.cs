using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Dto
{
    [DataContract]
    public class OperaterInfoDto
    {

        /// <summary>
        /// 操作员主键
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public bool? Sex { get; set; }


        /// <summary>
        /// 身份证号码
        /// </summary>
        [DataMember]
        public string IDCard { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// 催收人员类型名
        /// </summary>
        [DataMember]
        public string CollectionTypeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int? CollectionTypeId { get; set; }

        /// <summary>
        /// 归属部门
        /// </summary>
        [DataMember]
        public DepartmentInfoDto Department { get; set; }

        /// <summary>
        /// 角色ID列表
        /// </summary>
        [DataMember]
        public IList<int> RoleIdList { get; set; }


        [DataMember]
        public IList<DepartmentInfoDto> SupportDeptList { get; set; }
    }
}
