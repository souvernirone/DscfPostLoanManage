using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain.Map
{
    public class LoanProductOrderMap : EntityTypeConfiguration<LoanProductOrder>
    {
        public LoanProductOrderMap()
        {
            ToTable("T_LoanProductOrder");
            HasKey(order => order.OrderId);

            HasRequired(order => order.UserInfo).WithMany().HasForeignKey(order => order.UserId);

            HasRequired(order => order.OperaterInfo).WithMany().HasForeignKey(order => order.CreateUserId);

            HasMany(order => order.LoanMonthRepayList).WithRequired().HasForeignKey(repay => repay.LoanOrderId);
        }
    }
}
