using Dscf.CarLoan.Domain;
using Dscf.Common.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Manager
{
    //车贷展期
    public interface ICarLoanExtensionManager : IGenericManager<CarLoanExtension>
    {
        CarLoanExtension[] GetCarLoanExtensionList();
        
    }
}
