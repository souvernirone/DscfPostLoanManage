using Dscf.Common.Manager;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Manager
{
    public interface IRepayRemindManager : IGenericManager<RepayRemind>
    {
        RepayRemindDto[] GetRepayRemindListByKey(int repayId, int orderType);
        RemindExcleDto[] GetRepayRemindListByKeys(int productName, string signDate, string signDate1);
        bool AddRepayMindByDto(RepayRemindDto repayRemindDto, out RepayRemindDto dto);

        bool EditRepayMindByDto(RepayRemindDto repayRemindDto, out RepayRemindDto dto);

        bool DelRepayMindByDto(RepayRemindDto repayRemindDto);


    }
}
