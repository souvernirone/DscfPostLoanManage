using Dscf.CreditLoan.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/******************************
* Author:ztr 
* Date:2016/3/15
* Desc:合同编号工具类
*****************************/

namespace Dscf.CreditLoan.Dto.Extension
{
    /// <summary>
    /// 信用借款订单-合同编号工具类
    /// </summary>
    public static class ContractUtil
    {
        public static string GenerateContractNumber(LoanProductOrder order)
        {
            int? productTypeId = order.ProductTypeId;

            if (order.IsAccordanceProduct == true)
            {
                string[] changeNames = order.ChangeProductName.Split(',');
                productTypeId = Convert.ToInt32(changeNames[1]);
            }

            //产品合同代码
            string productCode = string.Empty;
            switch (productTypeId)
            {
                case 6: //新薪贷
                    productCode = "B";
                    break;
                case 7://助业贷
                    productCode = "C";
                    break;
                case 8://精英贷
                    productCode = "A";
                    break;
                case 31018://妈妈优业贷
                    productCode = "D";
                    break;
                case 31019://妈妈工薪贷
                    productCode = "E";
                    break;
                case 31020://妈妈生意贷
                    productCode = "F";
                    break;
                case 31021://分期贷
                    productCode = "G";
                    break;
                case 31022://乐消贷（幼儿教育）
                    productCode = "H";
                    break;
                case 31023://乐消贷（其他行业）
                    productCode = "I";
                    break;
            }
            return String.Format("{0}-{1}-{2}", order.OperaterInfo.DepartmentInfo.SignCity, productCode, order.OrderId); ;
        }

    }
}
