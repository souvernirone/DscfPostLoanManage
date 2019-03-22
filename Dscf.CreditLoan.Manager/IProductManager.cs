using Dscf.Common.Manager;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Manager
{
    public interface IProductManager : IGenericManager<Product>
    {
        /// <summary>
        /// 获取信贷产品信息
        /// </summary>
        /// <returns></returns>
        ProductDto[] GetLoanProductList(int type);
    }
}
