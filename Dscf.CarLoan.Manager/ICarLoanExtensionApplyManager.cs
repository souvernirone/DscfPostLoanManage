using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.Common.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Manager
{
    //借款月还款表
    public interface ICarLoanExtensionApplyManager : IGenericManager<CarLoanExtensionApply>
    {
        bool AddLoanExtensionApplyByDto(CarLoanExtensionApplyDto carLoanExtensionApplyDto);
    }
}
