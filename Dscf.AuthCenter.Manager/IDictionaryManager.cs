using Dscf.AuthCenter.Domain;
using Dscf.AuthCenter.Dto;
using Dscf.Common.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Manager
{
    public interface IDictionaryManager : IGenericManager<Dictionary>
    {
        DictionaryDto[] GetDictListByKey(string key);

        string GetRemindNameByType(string dictKey, int? type);
    }
}
