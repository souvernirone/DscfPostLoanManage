using Dscf.Common.Dao.Context;
using Dscf.Common.Dao.Implement;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dao.Implement
{
    //T_RepayRemind
    public class RepayRemindRepository : RepositoryBase<RepayRemind>, IRepayRemindRepository
    {
        public List<RepayRemindDto> GetRepayRemindListByKeys(int productName, string timeBegin, string timeEnd)
        {
            string SQL = @"SELECT [RepayId]
                          ,[OrderType]
                          ,[CreateTime]
                          ,[CreateOptId]
                          ,[IsDeleted]
                          ,[LastUpdateTime]
                          ,[LastOperateId]
                          ,[RemindType]
                          ,[RemindContent]
                      FROM [dbo].[T_RepayRemind]
                         WHERE 1=1
                    ";
            if (productName != 0)
            {
                SQL += " AND OrderType=" + productName + "";
            }
            try
            {
                DateTime.Parse(timeBegin);
                DateTime.Parse(timeEnd);
                SQL += " AND CreateTime BETWEEN '" + timeBegin + "' AND '" + timeEnd + "'";
            }
            catch (Exception)
            {

            }
            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            var list = unitOfWorkContex.Context.Database.SqlQuery<RepayRemindDto>(SQL).ToList();
            return list;
        }
    }
}
