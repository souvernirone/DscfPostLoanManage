using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class CarInfoMap : EntityTypeConfiguration<CarInfo>
    {
        public CarInfoMap()
        {
            ToTable("T_CarInfo");
            HasKey(c => c.CarInfoId);
        }
    }
}
