using Dscf.AuthCenter.Contract;
using Dscf.AuthCenter.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.AuthCenter.Dto;
using Dscf.PostLoanGlobal;

namespace Dscf.AuthCenter.Service
{
    public partial class AuthCenterService : IAuthCenterContract
    {
        public IOptDeptManager OptDeptManager { get; set; }

        public bool UpdateCollectorSupportCityList(int optId, int[] deptIdList, int sourceType)
        {
            return OptDeptManager.UpdateCollectorSupportCityList(optId, deptIdList, sourceType);
        }

        public int[] GetDeptIdsById(int key)
        {
          
            var roleList = GetRoleIdsById(key);
            if (roleList != null && (roleList.Contains(RoleUtil.CollectionSupervisor)))
            {
                return null;
            }

            var deptList = this.OptDeptManager.Entities.Where(optDep => optDep.OptId == key && optDep.DeptId != null).ToList();

            if (deptList.Count == 0)
            {
                return new int[] { -1 };
            }
            else
                return deptList.Select(optD => Convert.ToInt32(optD.DeptId)).ToArray();

        }
    }
}
