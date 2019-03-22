using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dscf.PostLoan.AuthCenterBLL.DscfACService;
using Dscf.PostLoanGlobal;

namespace Dscf.PostLoan.AuthCenterBLL
{
    public class OperaterInfoBLL
    {

        /// <summary>
        /// 查询拥有指定任一角色操作员列表
        /// </summary>
        /// <param name="roleIdList">指定角色ID列表</param>
        /// <returns></returns>
        public OperaterInfoDto[] QueryCollectorListByRole(IList<int> roleIdList)
        {
            using (DscfACService.AuthCenterContractClient client = new DscfACService.AuthCenterContractClient())
            {
                int[] collectorIdList = new int[] { RoleUtil.CarLoanCollectorRole, RoleUtil.CreditLoanCollectorRole };
                return client.GetCollectorListByRole(roleIdList.ToArray());
            }
        }

        public OptCityDto[] GetCollectorSupportCityList(int roleId, int typeId)
        {
            using (DscfACService.AuthCenterContractClient client = new DscfACService.AuthCenterContractClient())
            {
                return client.GetCollectorSupportCityList(roleId, typeId);
            }
        }

        public bool UpdateOptCollectionType(int optId, int type)
        {
            using (DscfACService.AuthCenterContractClient client = new DscfACService.AuthCenterContractClient())
            {
                return client.UpdateOptCollectionType(optId, type);
            }
        }
        public OperaterInfoDto[] GetCollectorListByRole(int[] roleIdArr)
        {
            using (DscfACService.AuthCenterContractClient client = new DscfACService.AuthCenterContractClient())
            {
                return client.GetCollectorListByRole(roleIdArr);
            }
        }
        public int[] GetRoleIdsById(int key)
        {
            using (DscfACService.AuthCenterContractClient client = new DscfACService.AuthCenterContractClient())
            {
                return client.GetRoleIdsById(key);
            }
        }

    }
}
