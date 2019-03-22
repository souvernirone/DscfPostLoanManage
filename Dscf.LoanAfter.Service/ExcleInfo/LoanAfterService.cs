using Dscf.LoanAfter.Contract;
using Dscf.LoanAfter.Domain;
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
        public IExcleInfoManager IExcleInfoManager { get; set; }
        /// <summary>
        /// 获取信贷产品信息
        /// </summary>
        /// <returns></returns>
        public ExcleInfoDto[] GetLoanAfterProduct(int type, int productTypeId)
        {
            return IExcleInfoManager.GetLoanAfterProduct(type, productTypeId);
        }

    }

}
