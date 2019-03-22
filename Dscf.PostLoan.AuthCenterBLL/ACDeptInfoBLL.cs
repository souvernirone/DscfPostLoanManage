using Dscf.PostLoan.AuthCenterBLL.DscfACService;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dscf.PostLoan.AuthCenterBLL.Extension;

namespace Dscf.PostLoan.AuthCenterBLL
{
    public class ACDeptInfoBLL
    {
        public DeptViewModel[] GetChildDeptListByDeptID(int parentDeptID)
        {
            using (AuthCenterContractClient client = new AuthCenterContractClient())
            {
                DepartmentInfoDto[] dtoList= client.GetChildDeptListByDeptID(parentDeptID);
                return dtoList.Select(dto=>dto.ToModel()).ToArray();
            }
        }
    }
}
