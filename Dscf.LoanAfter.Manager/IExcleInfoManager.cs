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
    public interface IExcleInfoManager 
    {
        /// <summary>
        /// 获取信贷产品信息
        /// </summary>
        /// <returns></returns>
        ExcleInfoDto[] GetLoanAfterProduct(int type, int productTypeId);

    }
 
}
