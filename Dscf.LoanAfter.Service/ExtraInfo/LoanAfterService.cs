/*******************************************************
*类名称：LoanAfterService
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/1 11:08:58
*说明：
*更新备注：
**********************************************************/

using Dscf.LoanAfter.Contract;
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
        public IExtraInfoManager ExtraInfoManager { get; set; }

        public ExtraInfoDto[] GetExtraInfoListByOrder(int orderId, int orderType)
        {
            return ExtraInfoManager.GetExtraInfoListByOrder(orderId, orderType);
        }

        public bool InsertExtraInfo(ExtraInfoDto extraDto, out ExtraInfoDto dto)
        {
            var entity = extraDto.ToEntity();
            var rowCount = ExtraInfoManager.Insert(entity);
            dto = entity.ToModel();
            return rowCount > 0 ? true : false;
        }

        public bool UpdateExtraInfo(ExtraInfoDto extraDto, out ExtraInfoDto dto)
        {
            var entity = ExtraInfoManager.GetByKey(extraDto.Id);
            entity.LastOperateId = extraDto.LastOperateId;
            entity.LastUpdateTime = extraDto.LastUpdateTime;
            entity.ExtraContent = extraDto.ExtraContent;
            var rowCount = ExtraInfoManager.Update(entity);
            dto = entity.ToModel();
            return rowCount > 0 ? true : false;
        }

        public bool DelExtraInfo(int id)
        {
            var entity = ExtraInfoManager.GetByKey(id);
            entity.IsDeleted = true;
            var rowCount = ExtraInfoManager.Update(entity);
            return rowCount > 0 ? true : false;
        }

    }
}
