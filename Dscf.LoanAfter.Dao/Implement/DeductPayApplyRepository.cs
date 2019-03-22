using Dscf.Common.Dao.Implement;
using Dscf.PostLoanGlobal;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dscf.LoanAfter.Dao.Implement
{
    //T_DeductPayApply
    public class DeductPayApplyRepository : RepositoryBase<DeductPayApply>, IDeductPayApplyRepository
    {
        public PagedList<DeductPayApplyDto> GetPageDeductPayList(int pageNum, int pageSize, IList<int> statusList = null, int? applyId = null, int? orderType = null)
        {
            PageCriteria criteria = new PageCriteria();
            criteria.Fields = @" dp.* ";
            criteria.PageSize = pageSize;
            criteria.CurrentPage = pageNum;
            criteria.TableName = @" T_DeductPayApply dp ";
            criteria.PrimaryKey = "dp.Id";
            criteria.Condition += @" and (dp.IsDeleted is null or  dp.IsDeleted=0) ";
            if (applyId == null)
            {
                if (statusList != null && statusList.Count > 0)
                {
                    criteria.Condition += string.Format(" and dp.ApprovalStatus in ({0}) ", string.Join<int>(",", statusList));
                }
                if (orderType != null)
                {
                    criteria.Condition += string.Format(" and dp.OrderType = {0} ", orderType);
                }
            }
            else
            {
                criteria.Condition += string.Format(" and dp.Id = {0} ", applyId);
            }
            return this.GetPageDataList<DeductPayApplyDto>(criteria);
        }
        public PagedList<DeductPayApplyDto> GetPageCarDeductApplyListDistinctOrderId(int pageNum, int pageSize, IList<int> statusList = null)
        {

            PageCriteria criteria = new PageCriteria();
            criteria.Fields = @" ttt.*";
            criteria.PageSize = pageSize;
            criteria.CurrentPage = pageNum;
            criteria.TableName = @" (SELECT  *, row_number() over (PARTITION BY OrderId ORDER BY Id DESC) as number
                                   FROM T_DeductPayApply  )  ttt ";
            criteria.PrimaryKey = "ttt.Id";
            criteria.Condition += @" and number=1  and OrderType=2";

            if (statusList != null && statusList.Count > 0)
            {
                criteria.Condition += string.Format(" and ttt.ApprovalStatus in ({0}) ", string.Join<int>(",", statusList));
            }
            return this.GetPageDataList<DeductPayApplyDto>(criteria);

        }

    }

}

