using Dscf.AuthCenter.Contract;
using Dscf.AuthCenter.Dto;
using Dscf.AuthCenter.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Service
{
    public partial class AuthCenterService : IAuthCenterContract
    {
        public IDictionaryManager DictionaryManager { get; set; }

        public DictionaryDto[] GetDictListByKey(string key)
        {
            return DictionaryManager.GetDictListByKey(key);
        }
        public string GetRemindNameByType(string dictKey, int? type)
        {
            return DictionaryManager.GetRemindNameByType(dictKey, type);
        }

    }
}
