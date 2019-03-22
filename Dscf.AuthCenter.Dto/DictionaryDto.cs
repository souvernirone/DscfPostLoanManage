using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Dto
{
    [DataContract]
    public class DictionaryDto
    {
        [DataMember]
        public int DictId { get; set; }

        [DataMember]
        public int? Parent { get; set; }

        [DataMember]
        public string DictKey { get; set; }

        [DataMember]
        public int? DictValue { get; set; }

        [DataMember]
        public string DictMemo { get; set; }

        [DataMember]
        public int? Sort { get; set; }
    }
}
