using Dscf.AuthCenter.Domain;
using Dscf.AuthCenter.Dto;
using Dscf.Common.Manager.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dscf.AuthCenter.Dto.Extension;

namespace Dscf.AuthCenter.Manager.Implement
{
    public class DictionaryManager : GenericManagerBase<Dictionary>, IDictionaryManager
    {
        public DictionaryDto[] GetDictListByKey(string key)
        {
            IList<Dictionary> dictList = this.CurrentRepository.Entities.Where(d => d.DictKey == key).ToList();
            return dictList.Select(dict => dict.ToModel()).OrderBy(dto => dto.Sort).ToArray();
        }
        public string GetRemindNameByType(string dictKey, int? type)
        {
            return this.CurrentRepository.Entities.Where(d => d.DictKey == dictKey && d.DictValue == type).FirstOrDefault().DictMemo;
        }
    }
}
