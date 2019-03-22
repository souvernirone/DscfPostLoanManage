using Dscf.PostLoan.AuthCenterBLL.DscfACService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.AuthCenterBLL
{
    public class DictionaryBLL
    {
        public DictionaryDto[] GetDictListByKey(string key)
        {
            using (DscfACService.AuthCenterContractClient client = new AuthCenterContractClient())
            {
                return client.GetDictListByKey(key);
            }
        }
        public string GetRemindNameByType(string dictKey, int? type)
        {
            using (DscfACService.AuthCenterContractClient client = new AuthCenterContractClient())
            {
                return client.GetRemindNameByType(dictKey, type);
            }
        }
    }
}
