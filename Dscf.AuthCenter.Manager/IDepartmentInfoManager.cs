using Dscf.AuthCenter.Domain;
using Dscf.AuthCenter.Dto;
using Dscf.Common.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Manager
{
    public interface IDepartmentInfoManager : IGenericManager<DepartmentInfo>
    {
        DepartmentInfoDto[] GetChildDeptListByDeptID(int parentDeptID);
        DepartmentInfoDto GetDeptByDeptID(int deptID);
    }
}
