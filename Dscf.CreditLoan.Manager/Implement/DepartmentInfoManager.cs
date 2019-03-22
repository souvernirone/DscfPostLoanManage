using Dscf.Common.Manager.Implement;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.CreditLoan.Dto.Extension;
using Dscf.CreditLoan.Dao;
using Dscf.PostLoanGlobal;
namespace Dscf.CreditLoan.Manager.Implement
{
    public class DepartmentInfoManager : GenericManagerBase<DepartmentInfo>, IDepartmentInfoManager
    {
        public IOperaterInfoRepository OperaterInfoRepository { get; set; }


        public DepartmentInfoDto[] GetChildDeptListByDeptID(int parentDeptID)
        {
            IList<DepartmentInfo> deptList = this.CurrentRepository.Entities.Where(dept => dept.ParentDepId == parentDeptID).ToList();
            return deptList.Select(dept => dept.ToModel()).ToArray();
        }

        public DepartmentInfoDto[] GetSupportCityList()
        {
            IList<int?> deptIdList = this.OperaterInfoRepository.Entities.Include("OperatorRoleList---")
               .Where(opt => opt.OperatorRoleList.Any(or => or.RoleId == RoleUtil.P2PCustomerServiceRole)).Select(opt => opt.DepId).Distinct()
               .ToList();
            IList<DepartmentInfo> deptList = this.CurrentRepository.Entities.Where(dept => deptIdList.Contains(dept.DepId)).Distinct().ToList();
            return deptList.Select(dept => dept.ToModel()).ToArray();
        }
    }
}
