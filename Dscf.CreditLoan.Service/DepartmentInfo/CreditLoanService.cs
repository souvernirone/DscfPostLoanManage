using Dscf.CreditLoan.Contract;
using Dscf.CreditLoan.Dto;
using Dscf.CreditLoan.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Service
{
    public partial class CreditLoanService : ICreditLoanContract
    {
        public IDepartmentInfoManager DepartmentInfoManager { get; set; }


        /// <summary>
        /// 根据部门父id获取子部门信息
        /// </summary>
        /// <param name="parentDeptID"></param>
        /// <returns></returns>
        public DepartmentInfoDto[] GetChildDeptListByDeptID(int parentDeptID)
        {
            return DepartmentInfoManager.GetChildDeptListByDeptID(parentDeptID);
        }

        public DepartmentInfoDto[] GetSupportCityList()
        {
            return DepartmentInfoManager.GetSupportCityList();
        }

    }
}
