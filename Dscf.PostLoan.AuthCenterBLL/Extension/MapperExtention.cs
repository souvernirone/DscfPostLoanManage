using AutoMapper;
using Dscf.PostLoan.AuthCenterBLL.DscfACService;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.AuthCenterBLL.Extension
{
    /// <summary>
    /// AutoMapper映射扩展
    /// </summary>
    public static class MapperExtention
    {
        #region ACDepartmentDto
        public static DeptViewModel ToModel(this DepartmentInfoDto entity)
        {
            return Mapper.DynamicMap<DepartmentInfoDto, DeptViewModel>(entity);
        }
        #endregion
    }
}
