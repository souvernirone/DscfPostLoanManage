using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    [DataContract]
    public class CreditCountDto
    {

        [DataMember]
        public int ShortNum { get; set; }

        [DataMember]
        public int AllNum { get; set; }



    }
}
