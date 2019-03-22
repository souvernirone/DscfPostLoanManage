using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.LoanAfterBLL
{
    public class CollectionInfoBLL
    {
        public bool InsertCollectionInfoAndUpFile(CollectionInfoDto dto)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.InsertCollectionInfoAndUpFile(dto);
            }
        }
        public CollectionInfoDto[] GetCollectionInfoByKey(int orderId, int orderType)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.GetCollectionInfoByKey(orderId, orderType);
            }
        }
        public bool DelCollectionInfo(int id, int operaterId)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.DelCollectionInfo(id, operaterId);
            }
        }
        public bool UpdateCollectionInfo(CollectionInfoDto dto, out CollectionInfoDto collection)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.UpdateCollectionInfo(dto, out collection);
            }
        }

    }
}
