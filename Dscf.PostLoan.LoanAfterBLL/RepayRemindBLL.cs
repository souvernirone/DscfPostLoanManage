using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.LoanAfterBLL
{
    public class RepayRemindBLL
    {
        public RepayRemindDto[] GetRepayRemindListByKey(int repayId, int orderType)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.GetRepayRemindListByKey(repayId, orderType);

            }
        }
        public RemindExcleDto[] GetRepayRemindListByKeys(int productName, string timeBegin, string timeEnd)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.GetRepayRemindListByKeys(productName, timeBegin, timeEnd);
            }
        }
        public bool AddRepayRemind(int repayId, string remindContent, int? repayRemindType, int orderType, int optId, out RepayRemindDto dto)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                RepayRemindDto repayRemindDto = new RepayRemindDto();
                repayRemindDto.RepayId = repayId;
                repayRemindDto.RemindContent = remindContent;
                repayRemindDto.RemindType = repayRemindType;
                repayRemindDto.OrderType = orderType;
                repayRemindDto.CreateOptId = optId;
                return client.AddRepayMindByDto(repayRemindDto, out dto);
            }
        }
        public bool EditRepayRemind(int remindId, string remindContent, int? repayRemindType, int optId, out RepayRemindDto dto)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                RepayRemindDto repayRemindDto = new RepayRemindDto();
                repayRemindDto.RemindId = remindId;
                repayRemindDto.RemindContent = remindContent;
                repayRemindDto.RemindType = repayRemindType;
                repayRemindDto.LastOperateId = null;
                repayRemindDto.LastUpdateTime = DateTime.Now;
                return client.EditRepayMindByDto(repayRemindDto, out dto);
            }
        }
        public bool DelRepayRemind(int remindId)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                RepayRemindDto repayRemindDto = new RepayRemindDto();
                repayRemindDto.RemindId = remindId;
                repayRemindDto.LastOperateId = null;
                repayRemindDto.LastUpdateTime = DateTime.Now;
                return client.DelRepayMindByDto(repayRemindDto);
            }

        }
    }
}
