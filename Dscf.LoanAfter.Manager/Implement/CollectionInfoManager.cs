using Dscf.Common.Manager.Implement;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using Dscf.LoanAfter.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Manager.Implement
{
    public class CollectionInfoManager : GenericManagerBase<CollectionInfo>, ICollectionInfoManager
    {
        public ICollectionInfoRepository CollectionInfoRepository { get; set; }
        public CollectionInfoDto[] GetCollectionInfoByKey(int orderId, int orderType)
        {
            IList<CollectionInfoDto> collectionInfoDtoList = new List<CollectionInfoDto>();
            List<CollectionInfo> collectionInfoList = this.Entities.Where(collectionInfo => collectionInfo.OrderId == orderId && collectionInfo.OrderType == orderType && collectionInfo.IsDeleted != true).ToList();
            foreach (var collection in collectionInfoList)
            {
                collectionInfoDtoList.Add(collection.ToModel());
            }

            return collectionInfoDtoList.ToArray();
        }
        public bool Del(int id, int operaterId)
        {
            var entity = this.CollectionInfoRepository.Entities.Where(collectionInfo => collectionInfo.Id == id).FirstOrDefault();
            entity.IsDeleted = true;
            entity.LastOperateId = operaterId;
            entity.LastUpdateTime = DateTime.Now;
            return this.CollectionInfoRepository.Update(entity) > 0 ? true : false;
        }
        public bool UpdateCollectionInfo(CollectionInfoDto dto, out CollectionInfoDto collection)
        {
            var entity = this.CollectionInfoRepository.Entities.Where(collec => collec.Id == dto.Id).FirstOrDefault();
            entity.CollectionRecord = dto.CollectionRecord;
            entity.CollectionStatus = dto.CollectionStatus;
            entity.LastOperateId = dto.LastOperateId;
            entity.LinkPersonType = dto.LinkPersonType;
            entity.OutboundAddress = dto.OutboundAddress;
            entity.LastUpdateTime = DateTime.Now;
            var boolean = this.CollectionInfoRepository.Update(entity) > 0 ? true : false;
            collection = entity.ToModel();
            return boolean;
        }
    }
}
