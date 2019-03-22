using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.CreditLoanBLL
{
    public class CreditLoanDeptInfoBLL
    {
        public DeptViewModel[] GetSupportDeptList()
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                DscfCreditLoanService.DepartmentInfoDto[] dtoList = client.GetSupportCityList();
                return dtoList.Select(dto => dto.ToModel()).ToArray();
            }
        }
    }
}
