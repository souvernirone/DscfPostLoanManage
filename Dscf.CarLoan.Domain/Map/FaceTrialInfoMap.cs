using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class FaceTrialInfoMap : EntityTypeConfiguration<FaceTrialInfo>
    {
        public FaceTrialInfoMap()
        {
            ToTable("T_FaceTrialInfo");
            HasKey(ftInfo => ftInfo.FaceTrailId);

            HasOptional(ccInfo => ccInfo.CarLoanConfig).WithMany().HasForeignKey(ccInfo => ccInfo.ProductTypeId);

        }
    }
}
