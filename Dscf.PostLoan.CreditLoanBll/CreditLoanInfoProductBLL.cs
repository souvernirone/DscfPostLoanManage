using Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.CreditLoanBLL
{

    public class CreditLoanInfoProductBLL
    {
        /// <summary>
        /// 获取信贷产品信息
        /// </summary>
        /// <returns></returns>
        public ProductDto[] GetLoanProduct(int type)
        {
            using (CreditLoanContractClient client = new CreditLoanContractClient())
            {
                DscfCreditLoanService.ProductDto[] proList = client.GetLoanProductList(type);
                return proList;
            }
        }


    }
}
