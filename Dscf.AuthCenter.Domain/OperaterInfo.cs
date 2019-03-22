using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Domain
{
    /// <summary>
    /// 认证中心-操作员信息
    /// </summary>
    public class OperaterInfo
    {
        /// <summary>
        /// 操作员主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? EntryDate { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? QuitDate { get; set; }

        /// <summary>
        /// 工作邮箱
        /// </summary>
        public string WorkEmail { get; set; }

        /// <summary>
        /// 微信号码
        /// </summary>
        public string WeiXin { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool? Sex { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 直属上级
        /// </summary>
        public int? ParentOptId { get; set; }

        /// <summary>
        /// 归属部门
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreateOptId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 所在公司
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// 目前职位
        /// </summary>
        public int? PositionId { get; set; }


        public int? CollectionTypeId { get; set; }

        /// <summary>
        /// 导航属性-角色列表
        /// </summary>
        public virtual IList<Role> RoleList { get; set; }


        /// <summary>
        /// 导航属性-操作员部门列表
        /// </summary>
        public virtual IList<OptDept> OptDeptList { get; set; }

        /// <summary>
        /// 导航属性-部门信息
        /// </summary>
        public virtual DepartmentInfo DepartmentInfo { get; set; }



    }
}
