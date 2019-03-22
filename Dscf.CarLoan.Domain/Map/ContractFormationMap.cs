using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class ContractFormationMap : EntityTypeConfiguration<ContractFormation>
    {
        public ContractFormationMap()
        {
            ToTable("T_ContractFormation");
            HasKey(contract => contract.ID);
        }
    }
}
