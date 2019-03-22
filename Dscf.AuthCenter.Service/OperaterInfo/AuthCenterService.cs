using Dscf.AuthCenter.Contract;
using Dscf.AuthCenter.Dto;
using Dscf.AuthCenter.Manager;
using Dscf.AuthCenter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Service
{
    public partial class AuthCenterService : IAuthCenterContract
    {
        public IOperaterInfoManager OperaterInfoManager { get; set; }

        public OperaterInfoDto[] GetCollectorListByRole(int[] roleIdArr)
        {
            return OperaterInfoManager.GetCollectorListByRole(roleIdArr);
        }

        public OptCityDto[] GetCollectorSupportCityList(int roleId, int typeId)
        {
            return OperaterInfoManager.GetCollectorSupportCityList(roleId, typeId);
        }

        public bool UpdateOptCollectionType(int optId, int type)
        {
            return OperaterInfoManager.UpdateOptCollectionType(optId, type);
        }

        public OperaterInfoDto GetOperaterInfoByID(int optId)
        {
            return OperaterInfoManager.GetOperaterInfoByID(optId);
        }

        public OperaterInfoDto[] GetOperaterInfoList(int[] optIdList)
        {
            return OperaterInfoManager.GetOperaterInfoList(optIdList);
        }

        public OperaterInfoDto[] GetOperaterInfoLists()
        {
            return OperaterInfoManager.GetOperaterInfoLists();
        }
        public int[] GetRoleIdsById(int key)
        {
            OperaterInfo operaterInfo = this.OperaterInfoManager.Entities.Include("RoleList").Where(opt => opt.Id == key && opt.IsDeleted != true).FirstOrDefault();
            if (operaterInfo == null)
            {
                return null;
            }
            else
                return operaterInfo.RoleList.Select(rol => rol.Id).ToArray();
        }

    }
}
