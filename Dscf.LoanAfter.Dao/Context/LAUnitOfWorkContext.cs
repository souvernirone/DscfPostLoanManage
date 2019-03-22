using Dscf.Common.Dao.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dao.Context
{
    class LAUnitOfWorkContext : UnitOfWorkContextBase
    {
        public override DbContext Context
        {
            get { return LADbContext.Value; }
        }


        public Lazy<LADbContext> LADbContext { get; set; }
    }
}
