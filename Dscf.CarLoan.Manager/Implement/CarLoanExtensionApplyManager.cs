using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.Common.Manager.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.CarLoan.Dto.Extension;


namespace Dscf.CarLoan.Manager.Implement
{
    public class CarLoanExtensionApplyManager : GenericManagerBase<CarLoanExtensionApply>, ICarLoanExtensionApplyManager
    {
        public bool AddLoanExtensionApplyByDto(CarLoanExtensionApplyDto carLoanExtensionApplyDto)
        {
            var carLoanExtensionApply = carLoanExtensionApplyDto.ToEntity();
            carLoanExtensionApply.CreateTime = DateTime.Now;
            return this.CurrentRepository.Insert(carLoanExtensionApply) > 0 ? true : false;
        }
    }
}
