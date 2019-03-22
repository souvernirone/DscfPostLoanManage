using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    [DataContract]
    public class CarUserInfoDto
    {
        [DataMember]
        public string Name { get; set; }
    }
}
