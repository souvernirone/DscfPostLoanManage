using Dscf.Common.Dao;
using Dscf.PostLoanGlobal;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dao
{
    //T_DeductPayApply
    public interface IDeductPayApplyRepository : IRepository<DeductPayApply>
    {
        PagedList<DeductPayApplyDto> GetPageDeductPayList(int pageNum, int pageSize, IList<int> statusList = null, int? applyId = null, int? OrderType = null);

        PagedList<DeductPayApplyDto> GetPageCarDeductApplyListDistinctOrderId(int pageNum, int pageSize, IList<int> statusList=null);
    }
}
