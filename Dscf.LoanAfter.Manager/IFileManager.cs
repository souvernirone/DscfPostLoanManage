using Dscf.Common.Manager;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Manager
{
    //T_File
    public interface IFileManager : IGenericManager<FileEntity>
    {
        UpFileResultMessage UpLoadFile(UpFileMessage fileMessage);
    }
}
