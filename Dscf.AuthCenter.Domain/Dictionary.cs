using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Domain
{
    public class Dictionary
    {
        public int DictId { get; set; }

        public int? Parent { get; set; }
        public string DictKey { get; set; }

        public int? DictValue { get; set; }

        public string DictMemo { get; set; }

        public int? Sort { get; set; }

        public DateTime CreateTime { get; set; }

        public int? OperateId { get; set; }

        public int? LastOperateId { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public int? IsEnable { get; set; }

        public int? IsDelete { get; set; }
    }
}
