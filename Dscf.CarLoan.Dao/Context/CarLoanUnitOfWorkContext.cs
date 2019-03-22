using Dscf.Common.Dao.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dao.Context
{
    public class CarLoanUnitOfWorkContext : UnitOfWorkContextBase
    {
        public override DbContext Context
        {
            get { return CarLoanDbContext.Value; }
        }


        public Lazy<CarLoanDbContext> CarLoanDbContext { get; set; }
    }
}
