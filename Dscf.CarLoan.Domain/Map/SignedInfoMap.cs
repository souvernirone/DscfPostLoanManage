using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class SignedInfoMap : EntityTypeConfiguration<SignedInfo>
    {
        public SignedInfoMap()
        {
            ToTable("T_SignedInfo");
            HasKey(sign => sign.SignId);
        }
    }
}
