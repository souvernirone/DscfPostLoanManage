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
    public interface ICollectionInfoManager : IGenericManager<CollectionInfo>
    {
        CollectionInfoDto[] GetCollectionInfoByKey(int orderId, int orderType);
        bool Del(int id, int operaterId);
        bool UpdateCollectionInfo(CollectionInfoDto dto, out CollectionInfoDto collection);
    }
}
