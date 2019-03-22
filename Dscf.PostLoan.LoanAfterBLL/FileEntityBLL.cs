using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.LoanAfterBLL
{
    public class FileEntityBLL
    {
        public UpFileResultMessage UpLoadFile(UpFileMessage fileMessage)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                UpFileResultMessage resultMsg = new UpFileResultMessage();
                string fileName = client.UpLoadFile(fileMessage.IsImage, fileMessage.OriginalFileName, fileMessage.ThumbHeight, fileMessage.ThumbWidth, fileMessage.FileStream,
                     out resultMsg.FilePath, out resultMsg.FileSuffix, out resultMsg.IsSuccess, out resultMsg.Message, out resultMsg.SaveFileName,
                    out resultMsg.ThumbPath);
                resultMsg.FileName = fileName;
                return resultMsg;
            }
        }
    }
}
