using Dscf.LoanAfter.Contract;
using Dscf.LoanAfter.Dto;
using Dscf.LoanAfter.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Service
{
    public partial class LoanAfterService : ILoanAfterContract
    {
        public IRepayRemindManager RepayRemindManager { get; set; }
        public RepayRemindDto[] GetRepayRemindListByKey(int repayId, int orderType)
        {
            return RepayRemindManager.GetRepayRemindListByKey(repayId, orderType);
        }
        /// <summary>
        /// 获取所有提醒信息Excle
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="timeBegin"></param>
        /// <param name="timeEnd"></param>
        /// <returns></returns>
        public RemindExcleDto[] GetRepayRemindListByKeys(int productName, string timeBegin, string timeEnd)
        {
            return RepayRemindManager.GetRepayRemindListByKeys(productName, timeBegin, timeEnd);
        }
        public bool AddRepayMindByDto(RepayRemindDto repayRemindDto, out RepayRemindDto dto)
        {
            return RepayRemindManager.AddRepayMindByDto(repayRemindDto, out dto);
        }

        public bool EditRepayMindByDto(RepayRemindDto repayRemindDto, out RepayRemindDto dto)
        {
            return RepayRemindManager.EditRepayMindByDto(repayRemindDto, out dto);
        }

        public bool DelRepayMindByDto(RepayRemindDto repayRemindDto)
        {
            return RepayRemindManager.DelRepayMindByDto(repayRemindDto);
        }


    }
}
