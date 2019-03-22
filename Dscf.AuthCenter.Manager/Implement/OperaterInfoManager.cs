using Dscf.AuthCenter.Domain;
using Dscf.AuthCenter.Dto;
using Dscf.Common.Manager.Implement;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dscf.AuthCenter.Dto.Extension;
using Dscf.AuthCenter.Dao;

namespace Dscf.AuthCenter.Manager.Implement
{
    public class OperaterInfoManager : GenericManagerBase<OperaterInfo>, IOperaterInfoManager
    {
        public IDictionaryRepository DictionaryRepository { get; set; }

        public IDepartmentInfoManager DepartmentInfoManager { get; set; }

        public IOptDeptRepository OptDeptRepository { get; set; }

        public OperaterInfoDto[] GetCollectorListByRole(int[] roleIdArr)
        {
            if (roleIdArr == null || roleIdArr.Length <= 0)
            {
                roleIdArr = new int[] { RoleUtil.CreditLoanCollectorRole, RoleUtil.CarLoanCollectorRole };
            }

            //加载P2P部门信息列表-引用服务DscfCreditLoanService
            IList<Dto.DscfCreditLoanService.DepartmentInfoDto> p2pDeptInfoList = new List<Dto.DscfCreditLoanService.DepartmentInfoDto>();

            if (roleIdArr.Contains(RoleUtil.CreditLoanCollectorRole))
            {
                using (Dscf.AuthCenter.Dto.DscfCreditLoanService.CreditLoanContractClient client = new Dscf.AuthCenter.Dto.DscfCreditLoanService.CreditLoanContractClient())
                {
                    p2pDeptInfoList = client.GetSupportCityList();
                }
            }


            IList<Dictionary> CollectionTypeList = this.DictionaryRepository.Entities.Where(d => d.DictKey == "CollectionType").ToList();

            IList<OperaterInfo> OperaterInfoList = this.CurrentRepository.Entities.Include("RoleList").Include("OptDeptList")
                .Where(opt => opt.IsDeleted != true && opt.RoleList.Any(r => roleIdArr.Contains(r.Id))).ToList();

            IList<OperaterInfoDto> optDtoList = new List<OperaterInfoDto>();

            IList<DepartmentInfoDto> deptDtoList = this.DepartmentInfoManager.GetChildDeptListByDeptID(DeptUtil.CarLoanBUKey).ToList();

            foreach (OperaterInfo opt in OperaterInfoList)
            {
                OperaterInfoDto dto = opt.ToModel();
                var type = CollectionTypeList.Where(dict => dict.DictValue == dto.CollectionTypeId).FirstOrDefault();
                dto.CollectionTypeName = type == null ? String.Empty : type.DictMemo;

                bool isCarLoanCeletor = opt.RoleList.Where(role => role.Id == RoleUtil.CarLoanCollectorRole).Count() > 0;
                if (isCarLoanCeletor)
                {
                    dto.SupportDeptList = deptDtoList.Where(deptDto => opt.OptDeptList.Select(od => od.DeptId).Contains(deptDto.Id)).ToList();
                }
                else
                {
                    IList<Dscf.AuthCenter.Dto.DscfCreditLoanService.DepartmentInfoDto> p2pDtoList = p2pDeptInfoList.Where(deptDto => opt.OptDeptList.Select(od => od.DeptId).Contains(deptDto.DepId)).ToList();
                    dto.SupportDeptList = p2pDtoList.Select(p2pDto => p2pDto.ToModel()).ToList();
                }


                optDtoList.Add(dto);
            }

            return optDtoList.ToArray();
        }


        public OptCityDto[] GetCollectorSupportCityList(int roleId, int typeId)
        {
            int sourceType = roleId == RoleUtil.CreditLoanCollectorRole ? 2 : 1;

            var optDeptList = this.OptDeptRepository.Entities.Where(od => od.SourceType == sourceType).ToList();
            var optIdList = optDeptList.Select(od => od.OptId);


            IList<OperaterInfo> OperaterInfoList = this.CurrentRepository.Entities.Include("OptDeptList")
               .Where(opt => optIdList.Contains(opt.Id) && opt.CollectionTypeId == typeId && opt.IsDeleted != true).ToList();
            var optCityDtoArray = OperaterInfoList.Select(opt => new OptCityDto
            {
                Id = opt.Id,
                SupportDeptList = opt.OptDeptList.Select(od => od.DeptId).ToList()
            }).ToArray();
            return optCityDtoArray;
        }


        public bool UpdateOptCollectionType(int optId, int type)
        {
            OperaterInfo optInfo = this.CurrentRepository.GetByKey(optId);
            if (optInfo != null)
            {
                optInfo.CollectionTypeId = type;
                this.OptDeptRepository.Delete(optInfo.OptDeptList, false);
                this.CurrentRepository.Update(optInfo);
                return true;
            }
            return false;
        }

        public OperaterInfoDto GetOperaterInfoByID(int optId)
        {
            OperaterInfo opt = this.CurrentRepository.GetByKey(optId);
            return EntityToDto(opt);
        }

        public OperaterInfoDto[] GetOperaterInfoList(int[] optIdList)
        {
            IList<OperaterInfoDto> optDtoList = new List<OperaterInfoDto>();
            var optList = this.CurrentRepository.Entities.Include("DepartmentInfo").Where(opt => optIdList.Contains(opt.Id));
            foreach (var opt in optList)
            {
                var optDto = EntityToDto(opt);
                optDtoList.Add(optDto);
            }
            return optDtoList.ToArray();
        }
        public OperaterInfoDto[] GetOperaterInfoLists()
        {
            IList<OperaterInfoDto> optDtoList = new List<OperaterInfoDto>();
            var optList = this.CurrentRepository.Entities.Include("DepartmentInfo");
            foreach (var opt in optList)
            {
                var optDto = EntityToDto(opt);
                optDtoList.Add(optDto);
            }
            return optDtoList.ToArray();
        }

        /// <summary>
        /// Entity2Dto转换工具
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        public OperaterInfoDto EntityToDto(OperaterInfo opt)
        {
            OperaterInfoDto optDto = new OperaterInfoDto()
          {
              Id = opt.Id,
              Name = opt.Name,
              Sex = opt.Sex,
              IDCard = opt.IDCard,
              Phone = opt.Phone,
              CollectionTypeId = opt.CollectionTypeId,
              Department = opt.DepartmentInfo.ToModel()
          };
            return optDto;
        }
    }
}
