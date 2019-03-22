using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class LoanProductOrderMap : EntityTypeConfiguration<LoanProductOrder>
    {
        public LoanProductOrderMap()
        {
            ToTable("T_LoanProductOrder");
            HasKey(p => p.ProductOrderId);
            //用户信息
            HasRequired(order => order.UserInfo).WithMany().HasForeignKey(order => order.UserId);
            //月还款信息
            HasMany(order => order.LoanMonthRepayList).WithRequired().HasForeignKey(repay => repay.LoanOrderId);
            //合同信息
            HasMany(order => order.ContractFormationList).WithRequired().HasForeignKey(contract => contract.LoanOrderId);
            //划扣信息
            HasMany(order => order.DeductProgressList).WithRequired().HasForeignKey(deduct => deduct.OrderId);
        }
    }
}
