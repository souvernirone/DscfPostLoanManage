/*******************************************************
*类名称：ExtraInfoManager
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/1 11:05:43
*说明：
*更新备注：
**********************************************************/

using Dscf.Common.Manager.Implement;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Manager.Implement
{
    public class ExtraInfoManager : GenericManagerBase<ExtraInfo>, IExtraInfoManager
    {
        public ExtraInfoDto[] GetExtraInfoListByOrder(int orderId, int orderType)
        {
            IList<ExtraInfoDto> dtoList = new List<ExtraInfoDto>();

            var extraInfoList= this.Entities.Where(extra => extra.OrderId == orderId && extra.OrderType == orderType
                && extra.IsDeleted != true).ToList();

            Dto.DscfACService.OperaterInfoDto[] optDtoArray;

            var optIdArray = extraInfoList.Select(extra => extra.CreateOptId.HasValue ? extra.CreateOptId.Value : -1).Distinct().ToArray();

            using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
            {
                optDtoArray = client.GetOperaterInfoList(optIdArray);
            }

            foreach (var extra in extraInfoList)
            {
                ExtraInfoDto extraDto = extra.ToModel();
                if (extra.CreateOptId.HasValue && optDtoArray != null)
                {
                    Dto.DscfACService.OperaterInfoDto optDto = optDtoArray.Where(dto => dto.Id == extra.CreateOptId.Value).FirstOrDefault();
                    if (optDto != null)
                    {
                        extraDto.CreateOptName = optDto.Name;
                    }
                }
                dtoList.Add(extraDto);
            }

            return dtoList.ToArray();
        }
    }
}
