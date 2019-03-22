using Dscf.LoanAfter.Contract;
using Dscf.LoanAfter.Dto;
using Dscf.LoanAfter.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Service
{
    public partial class LoanAfterService : ILoanAfterContract
    {
        public IFileManager FileManager { get; set; }
        public UpFileResultMessage UpLoadFile(UpFileMessage fileMessage)
        {
            return FileManager.UpLoadFile(fileMessage);
        }
    }
}
