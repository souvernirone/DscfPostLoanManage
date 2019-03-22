using AutoMapper;
using Dscf.AuthCenter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Dto.Extension
{
    /// <summary>
    /// AutoMapper映射扩展
    /// </summary>
    public static class MapperExtention
    {
        #region OperaterInfo
        public static OperaterInfoDto ToModel(this OperaterInfo entity)
        {
            return Mapper.Map<OperaterInfo, OperaterInfoDto>(entity);
        }
        #endregion

        #region DepartmentInfo
        public static DepartmentInfoDto ToModel(this DepartmentInfo entity)
        {
            return Mapper.Map<DepartmentInfo, DepartmentInfoDto>(entity);
        }

        public static DepartmentInfoDto ToModel(this DscfCreditLoanService.DepartmentInfoDto entity)
        {
            return Mapper.Map<DscfCreditLoanService.DepartmentInfoDto, DepartmentInfoDto>(entity);
        }

        #endregion

        #region Dictionary
        public static DictionaryDto ToModel(this Dictionary entity)
        {
            return Mapper.Map<Dictionary, DictionaryDto>(entity);
        }
        #endregion

    }
}
