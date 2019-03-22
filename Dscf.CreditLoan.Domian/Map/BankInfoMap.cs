using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain.Map
{
    public class BankInfoMap : EntityTypeConfiguration<BankInfo>
    {
        public BankInfoMap()
        {
            ToTable("T_BankInfo");

            HasKey(bankInfo => bankInfo.BankInfoId);
        }
    }
}
