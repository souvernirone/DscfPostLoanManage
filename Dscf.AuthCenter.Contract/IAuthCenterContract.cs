using Dscf.AuthCenter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Contract
{
    [ServiceContract]
    public interface IAuthCenterContract
    {
        #region T_Role

        /// <summary>
        /// 根据ID获取所属角色Id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [OperationContract]
        int[] GetRoleIdsById(int key);

        #endregion

        #region T_Department
        /// <summary>
        /// 根据ID获取所负责部门Id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [OperationContract]
        int[] GetDeptIdsById(int key);
        /// <summary>
        /// 根据部门Id获取部门
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        [OperationContract]
        DepartmentInfoDto GetDeptByDeptID(int deptID);
        /// <summary>
        /// 根据ID获取所负责部门签署地名字
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [OperationContract]
        string[] GetDeptSignSitiesById(int key);

        #endregion

        #region T_OperaterInfo
        /// <summary>
        /// 查询催收人员列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        OperaterInfoDto[] GetCollectorListByRole(int[] roleIdArr);

        /// <summary>
        /// 查询指定部门的子部门列表
        /// </summary>
        /// <param name="parentDeptID">上级部门ID</param>
        /// <returns></returns>
        [OperationContract]
        DepartmentInfoDto[] GetChildDeptListByDeptID(int parentDeptID);



        /// <summary>
        /// 更新指定操作员的催收类型
        /// </summary>
        /// <param name="optId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateOptCollectionType(int optId, int type);


        /// <summary>
        /// 查询指定操作员信息
        /// 单表查询-T_OperaterInfo
        /// </summary>
        /// <param name="optId"></param>
        /// <returns></returns>
        [OperationContract]
        OperaterInfoDto GetOperaterInfoByID(int optId);


        /// <summary>
        /// 查询指定主键操作员信息列表
        /// 单表查询-T_OperaterInfo
        /// </summary>
        /// <param name="optId"></param>
        /// <returns></returns>
        [OperationContract]
        OperaterInfoDto[] GetOperaterInfoList(int[] optIdList);

        /// <summary>
        /// 查询操作员信息列表
        /// 单表查询-T_OperaterInfo
        /// </summary>
        /// <param name="optId"></param>
        /// <returns></returns>
        [OperationContract]
        OperaterInfoDto[] GetOperaterInfoLists();
        /// <summary>
        /// 查询拥有某一催收角色的MX类型催收员及其支持城市列表
        /// </summary>
        /// <param name="optId">指定操作员的主键ID</param>
        /// <returns></returns>
        [OperationContract]
        OptCityDto[] GetCollectorSupportCityList(int roleId, int typeId);

        #endregion

        #region T_Dictionary
        /// <summary>
        /// 查询指定DictKey的Dictionary列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [OperationContract]
        DictionaryDto[] GetDictListByKey(string key);

        /// <summary>
        /// 获取提醒类型获取提醒名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [OperationContract]
        string GetRemindNameByType(string dictKey, int? type);

        #endregion

        #region T_OptDept

        /// <summary>
        /// 更新指定催收人员负责的城市列表
        /// </summary>
        /// <param name="optId"></param>
        /// <param name="deptIdList"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateCollectorSupportCityList(int optId, int[] deptIdList, int sourceType);

        #endregion



    }
}
