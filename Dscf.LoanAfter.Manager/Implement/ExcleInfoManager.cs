using Dscf.Common.Manager.Implement;
using Dscf.PostLoanGlobal;
using Dscf.LoanAfter.Dto;
using Dscf.LoanAfter.Dto.DscfCreditLoanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Manager.Implement
{
    public class ExcleInfoManager : IExcleInfoManager
    {
        /// <summary>
        /// 获取信贷产品信息
        /// </summary>
        /// <returns></returns>
        public ExcleInfoDto[] GetLoanAfterProduct(int type, int productTypeId)
        {
            List<ExcleInfoDto> ExcleInfoList = new List<ExcleInfoDto>();
            ExcleInfoDto ExcleInfoDto = null;
            if (productTypeId == 1 || productTypeId == 0)
            {
                using (CreditLoanContractClient client = new CreditLoanContractClient())
                {
                    Dscf.LoanAfter.Dto.DscfCreditLoanService.ProductDto[] proList = client.GetLoanProductList(type);
                    foreach (var item in proList)
                    {
                        ExcleInfoDto = new ExcleInfoDto();
                        ExcleInfoDto.ProductId = item.ProductId;
                        ExcleInfoDto.ProductName = item.ProductName;
                        ExcleInfoDto.ProductType = LoanOrderUtil.CreditTypeKey;
                        ExcleInfoList.Add(ExcleInfoDto);
                    }

                }
            }
            if (productTypeId == 2 || productTypeId == 0)
            {
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    var carLoanTypeList = client.GetDictListByKey(DictUtil.CarLoanTypeKey);
                    foreach (var item in carLoanTypeList)
                    {
                        ExcleInfoDto = new ExcleInfoDto();
                        ExcleInfoDto.ProductId = item.DictValue.Value;
                        ExcleInfoDto.ProductName = item.DictMemo;
                        ExcleInfoDto.ProductType = LoanOrderUtil.CarTypeKey;
                        ExcleInfoList.Add(ExcleInfoDto);
                    }
                }
            }

            return ExcleInfoList.ToArray();
        }

    }
}
