using Dscf.AuthCenter.Domain;
using Dscf.AuthCenter.Dto;
using Dscf.Common.Manager.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dscf.AuthCenter.Dto.Extension;

namespace Dscf.AuthCenter.Manager.Implement
{
    public class DepartmentInfoManager : GenericManagerBase<DepartmentInfo>, IDepartmentInfoManager
    {
        public DepartmentInfoDto[] GetChildDeptListByDeptID(int parentDeptID)
        {
            IList<DepartmentInfo> deptList = this.CurrentRepository.Entities.Where(dept => dept.ParentDeptId == parentDeptID).ToList();
            return deptList.Select(dept => dept.ToModel()).ToArray();
        }
        public DepartmentInfoDto GetDeptByDeptID(int deptID)
        {
            DepartmentInfo deptList = this.CurrentRepository.Entities.Where(dept => dept.Id == deptID).FirstOrDefault();
            return deptList.ToModel();
        }
    }
}
