using Dscf.CarLoan.Contract;
using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.CarLoan.Manager;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dscf.CarLoan.Dto.Extension;

namespace Dscf.CarLoan.Service
{
    public partial class CarLoanService : ICarLoanContract
    {
        public IDeductProgressManager DeductProgressManager { get; set; }

        public DeductProgressDto[] GetDeductList(int orderId)
        {
            return DeductProgressManager.GetDeductList(orderId);
        }
        public Boolean AddCarDeductProgressByKey(IList<string> idAndPeriods, int operatorId)
        {
            return DeductProgressManager.AddCarDeductProgressByKey(idAndPeriods, operatorId);
        }

        /// <summary>
        /// 车贷单笔划扣，添加划扣信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public Boolean AddCarDeductProgressOne(DeductProgressDto model, int operatorId)
        {
            return DeductProgressManager.AddCarDeductProgressOne(model, operatorId);
        }
        public Boolean UpdateApplyIdByOrderId(int applyId, int orderId)
        {
            return DeductProgressManager.UpdateApplyIdByOrderId(applyId, orderId);
        }
    }
}
