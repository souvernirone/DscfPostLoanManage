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
    public interface IOperaterInfoManager : IGenericManager<OperaterInfo>
    {
        /// <summary>
        /// 查询拥有任一指定催收角色的催收人员列表
        /// </summary>
        /// <param name="roleIdArr"></param>
        /// <returns></returns>
        OperaterInfoDto[] GetCollectorListByRole(int[] roleIdArr);

        OptCityDto[] GetCollectorSupportCityList(int roleId, int typeId);

        bool UpdateOptCollectionType(int optId, int type);

        /// <summary>
        /// 查询指定操作员信息
        /// 单表查询-T_OperaterInfo
        /// </summary>
        /// <param name="optId"></param>
        /// <returns></returns>
        OperaterInfoDto GetOperaterInfoByID(int optId);

        OperaterInfoDto[] GetOperaterInfoList(int[] optIdList);

        OperaterInfoDto[] GetOperaterInfoLists();

    }
}
