using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.AuthCenterBLL
{
    public class OptDeptBLL
    {
        public bool UpdateCollectorSupportCityList(int optId, int[] deptIdList,int sourceType)
        {
            using (DscfACService.AuthCenterContractClient client = new DscfACService.AuthCenterContractClient())
            {
                return client.UpdateCollectorSupportCityList(optId, deptIdList, sourceType);
            }
        }
    }
}
