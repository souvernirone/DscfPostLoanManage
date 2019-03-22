using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Domain
{
    public class Role
    {

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// RoleId
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string RoleDescription { get; set; }

        /// <summary>
        /// 平台
        /// </summary>
        public int? PlatformId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreateOptId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }


        /// <summary>
        /// 最后修改人
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }


        /// <summary>
        /// 是否开放
        /// </summary>
        public bool? IsOpen { get; set; }

    }
}
