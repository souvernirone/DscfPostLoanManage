using Dscf.Common.Manager;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Manager
{
    public interface IDepartmentInfoManager : IGenericManager<DepartmentInfo>
    {
        DepartmentInfoDto[] GetChildDeptListByDeptID(int parentDeptID);

        /// <summary>
        /// 查询贷后支持城市列表
        /// </summary>
        /// <param name="parentDeptID"></param>
        /// <returns></returns>
        DepartmentInfoDto[] GetSupportCityList();
    }
}
