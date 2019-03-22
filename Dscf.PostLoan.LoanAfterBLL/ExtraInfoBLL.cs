/*******************************************************
*类名称：ExtraInfoBLL
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/1 11:34:05
*说明：
*更新备注：
**********************************************************/

using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.LoanAfterBLL
{
    public class ExtraInfoBLL
    {
        public ExtraInfoDto[] GetExtraInfoListByOrder(int orderId, int orderType)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.GetExtraInfoListByOrder(orderId, orderType);
            }
        }

        public bool InsertExtraInfo(ExtraInfoDto extraDto, out ExtraInfoDto dto)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.InsertExtraInfo(extraDto, out dto);
            }
        }
        public bool UpdateExtraInfo(ExtraInfoDto extraDto, out ExtraInfoDto dto)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.UpdateExtraInfo(extraDto, out dto);
            }
        }

        public bool DelExtraInfo(int id)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.DelExtraInfo(id);
            }
        }
    }
}
