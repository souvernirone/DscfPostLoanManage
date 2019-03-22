using Dscf.PostLoanGlobal;
using Dscf.PostLoan.CarLoanBLL.DscfCarLoanService;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.CarLoanBLL
{
    public class CarLoanExtensionApplyBLL
    {
        public bool AddLoanExtensionApply(int loanProductOrerId, decimal? derationAmount, string extensionMemo, int operatorId)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                CarLoanExtensionApplyDto carLoanExtensionApplyDto = new CarLoanExtensionApplyDto();
                carLoanExtensionApplyDto.LoanProductOrerId = loanProductOrerId;
                carLoanExtensionApplyDto.DerationAmount = derationAmount;
                carLoanExtensionApplyDto.ExtensionMemo = extensionMemo;
                carLoanExtensionApplyDto.LobbyId = null;
                carLoanExtensionApplyDto.OperateId = operatorId;
                carLoanExtensionApplyDto.CreateTime = DateTime.Now;
                carLoanExtensionApplyDto.IsEnable = 1;
                carLoanExtensionApplyDto.IsDelete = 0;
                return client.AddLoanExtensionApplyByDto(carLoanExtensionApplyDto);
            }
        }
    }
}
