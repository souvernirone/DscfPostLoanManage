/*******************************************************
*类名称：IExtraInfoManager
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/1 11:05:05
*说明：
*更新备注：
**********************************************************/

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
    public interface IExtraInfoManager : IGenericManager<ExtraInfo>
    {
        ExtraInfoDto[] GetExtraInfoListByOrder(int orderId, int orderType);
    }
}
