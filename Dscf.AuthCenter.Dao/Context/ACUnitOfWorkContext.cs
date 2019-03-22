using Dscf.Common.Dao.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Dao.Context
{
    public class ACUnitOfWorkContext : UnitOfWorkContextBase
    {
        public override DbContext Context
        {
            get { return ACDbContext.Value; }
        }


        public Lazy<ACDbContext> ACDbContext { get; set; }
    }
}
