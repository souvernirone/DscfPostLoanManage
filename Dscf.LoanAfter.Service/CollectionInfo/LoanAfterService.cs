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
        public ICollectionInfoManager CollectionInfoManager { get; set; }

        public bool InsertCollectionInfoAndUpFile(CollectionInfoDto dto)
        {
            var collectionInfo = dto.ToEntity();
            var row = CollectionInfoManager.Insert(collectionInfo);
            return row > 0 ? true : false;
        }
        public CollectionInfoDto[] GetCollectionInfoByKey(int orderId, int orderType)
        {
            return CollectionInfoManager.GetCollectionInfoByKey(orderId, orderType);
        }
        public bool DelCollectionInfo(int id, int operaterId)
        {
            return CollectionInfoManager.Del(id, operaterId);
        }
        public bool UpdateCollectionInfo(CollectionInfoDto dto, out CollectionInfoDto colletion)
        {
            return CollectionInfoManager.UpdateCollectionInfo(dto, out colletion);
        }

    }
}
