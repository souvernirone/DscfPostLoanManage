using Dscf.CarLoan.Domain;
using Dscf.Common.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.CarLoan.Dto;

namespace Dscf.CarLoan.Manager
{
    public interface IDeductProgressManager : IGenericManager<DeductProgress>
    {
        DeductProgressDto[] GetDeductList(int orderId);

        Boolean AddCarDeductProgressByKey(IList<string> idAndPeriods, int operatorId);

       /// <summary>
        /// 车贷单笔划扣，添加划扣信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        Boolean AddCarDeductProgressOne(DeductProgressDto model, int operatorId);
        Boolean UpdateApplyIdByOrderId(int applyId, int orderId);

    }
}
