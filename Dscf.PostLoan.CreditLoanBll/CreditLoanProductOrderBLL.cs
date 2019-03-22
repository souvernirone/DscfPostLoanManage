using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService;
using Dscf.PostLoanGlobal;

namespace Dscf.PostLoan.CreditLoanBLL
{
    public class CreditLoanProductOrderBLL
    {
        public bool UpdateReminder(int orderId, int deptOptId)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                return client.EditLoanOrderReminderByOrderId(orderId, deptOptId);
            }
        }
        public bool UpdateCollectStatus(int orderId, int collectStatus, int optId)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                return client.UpdateOrderCollectStatus(orderId, collectStatus, optId);
            }
        }
        public bool UpdateCollectStatusBatch(int[] orderIds, int collectStatus, int optId)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                return client.UpdateOrderCollectStatusBatch(orderIds, collectStatus, optId);
            }
        }
        public CreditCountDto GetIsRemindCount(int optId)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                return client.GetIsRemindCount(optId);
            }
        }
    }
}
