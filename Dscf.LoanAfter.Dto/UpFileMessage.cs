using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dto
{
    [MessageContract]
    public class UpFileMessage
    {

        [MessageHeader(MustUnderstand = true)]
        public string OriginalFileName { get; set; }

        [MessageHeader(MustUnderstand = true)]
        public bool IsImage { get; set; }

        [MessageBodyMember(Order = 1)]
        public Stream FileStream { get; set; }

        [MessageHeader(MustUnderstand = true)]
        public int? ThumbHeight { get; set; }

        [MessageHeader(MustUnderstand = true)]
        public int? ThumbWidth { get; set; }

    }
}
