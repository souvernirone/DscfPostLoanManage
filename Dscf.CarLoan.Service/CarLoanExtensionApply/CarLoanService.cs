using Dscf.CarLoan.Contract;
using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.CarLoan.Manager;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Service
{
    public partial class CarLoanService : ICarLoanContract
    {
        public ICarLoanExtensionApplyManager CarLoanExtensionApply { get; set; }
        public bool AddLoanExtensionApplyByDto(CarLoanExtensionApplyDto carLoanExtensionApplyDto)
        {
            return CarLoanExtensionApply.AddLoanExtensionApplyByDto(carLoanExtensionApplyDto);
        }
    }
}
