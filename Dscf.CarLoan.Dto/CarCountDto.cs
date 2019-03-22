using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    [DataContract]
    public class CarCountDto
    {
        /// <summary>
        /// 车贷
        /// </summary>        
        [DataMember]
        public int ShortNum { get; set; }

        [DataMember]
        public int AllNum { get; set; }



    }
}
