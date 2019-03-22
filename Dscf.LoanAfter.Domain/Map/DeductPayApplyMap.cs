using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Domain.Map
{
    public class DeductPayApplyMap : EntityTypeConfiguration<DeductPayApply>
    {
        public DeductPayApplyMap()
        {
            ToTable("T_DeductPayApply");
            HasKey(deduct => deduct.Id);

            HasRequired(apply => apply.FileEntity).WithMany().HasForeignKey(apply => apply.FileId);
        }
    }
}
