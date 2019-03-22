using Dscf.Common.Dao.Implement;
using Dscf.CreditLoan.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.PostLoanGlobal;
using System.Data;
using Dscf.CreditLoan.Dao.Context;
using Dscf.CreditLoan.Dto;
using System.Data.SqlClient;
using Dscf.Common.Dao.Context;

namespace Dscf.CreditLoan.Dao.Implement
{
    public class LoanProductOrderRepository : RepositoryBase<LoanProductOrder>, ILoanProductOrderRepository
    {
        public PagedList<LoanInfoDto> GetPageLoanInfoList(LoanSearchViewModel loanSearchViewModel)
        {
            PageCriteria criteria = new PageCriteria();
            criteria.Fields = @" lo.OrderId,u.Name,dept.SignCity,dept.DepId ,u.Phone, u.IDCard, 
                                p.ProductName,lo.Amount,lo.SignDate,lo.DeptOptId,
                                lo.DeductBankName,lo.DeductBranchBank,
                                lo.DeductBankAccount,
                                (dept.SignCity+'-'+ CASE p.ProductId WHEN  6 THEN  'B' WHEN 7  THEN 'C' WHEN 8  THEN 'A'
                                                                     WHEN 31018  THEN 'D' WHEN 31019  THEN 'E'  WHEN 31020  THEN 'F'
                                                                     WHEN 31021  THEN 'G' WHEN 31022  THEN 'H'  WHEN 31023  THEN 'I'
                                                                     WHEN 31024 THEN 'J'
                                                                     ELSE '' END + '-'+ convert(nvarchar,lo.OrderId))  AS Contract ";
            criteria.PageSize = loanSearchViewModel.PageSize;
            criteria.CurrentPage = loanSearchViewModel.PageNum;
            criteria.TableName = @"T_OperaterInfo opt INNER JOIN T_LoanProductOrder lo ON opt.OptId =lo.CreateUserId
                                                      INNER JOIN T_UserInfo u  ON  u.UserId = lo.UserId    
                                                      INNER JOIN T_DepartmentInfo dept ON opt.DepId = dept.DepId 
                                                      INNER JOIN T_Product p ON   p.ProductId= CASE  lo.IsAccordanceProduct 
                                                            WHEN 1 then RIGHT(lo.ChangeProductName,LEN(lo.ChangeProductName)-CHARINDEX(',',lo.ChangeProductName))
                                                            ELSE  lo.ProductTypeId END";
            criteria.PrimaryKey = "lo.OrderId";

            criteria.Condition += " and lo.VerifyStatus in (1025, 1014) ";
            criteria.Condition += string.Format(" and (lo.IsDeleted={0} or lo.IsDeleted is null) ", 0);
            //排序
            criteria.Sort = " lo.SignDate desc ";

            if (!string.IsNullOrEmpty(loanSearchViewModel.OrderId))
            {
                criteria.Condition += string.Format("  and lo.OrderId='{0}' ", loanSearchViewModel.OrderId);
            }
            if (!string.IsNullOrEmpty(loanSearchViewModel.Name))
            {
                criteria.Condition += string.Format("  and u.Name='{0}' ", loanSearchViewModel.Name);
            }
            if (!string.IsNullOrEmpty(loanSearchViewModel.IdCard))
            {
                criteria.Condition += string.Format(" and u.IDCard='{0}' ", loanSearchViewModel.IdCard);
            }
            if (!string.IsNullOrEmpty(loanSearchViewModel.ProductName))
            {
                criteria.Condition += string.Format("  and p.ProductName='{0}' ", loanSearchViewModel.ProductName);
            }
            if (!string.IsNullOrEmpty(loanSearchViewModel.UserPhone))
            {
                criteria.Condition += string.Format("  and u.Phone='{0}' ", loanSearchViewModel.UserPhone);
            }
            if (!string.IsNullOrEmpty(loanSearchViewModel.City))
            {
                criteria.Condition += string.Format(" and dept.SignCity='{0}' ", loanSearchViewModel.City);
            }
            //if (!string.IsNullOrEmpty(loanSearchViewModel.ContractNo))
            //{
            //    criteria.Condition += string.Format(" and Contract='{0}' ", loanSearchViewModel.ContractNo);
            //}
            if (!string.IsNullOrEmpty(loanSearchViewModel.SignTimeFrom))
            {
                criteria.Condition += string.Format(" and lo.SignDate>='{0}' ", loanSearchViewModel.SignTimeFrom);
            }
            if (!string.IsNullOrEmpty(loanSearchViewModel.SignTimeTo))
            {
                criteria.Condition += string.Format(" and lo.SignDate<='{0}' ", loanSearchViewModel.SignTimeTo);
            }
            //if(loanSearchViewModel.RoleIds)
            if (loanSearchViewModel.DeptIds == null)
            {
                return this.GetPageDataList<LoanInfoDto>(criteria);
            }

            else
            {
                string u = string.Join<int>(",", loanSearchViewModel.DeptIds);
                criteria.Condition += string.Format(" and (lo.DeptOptId is null and dept.DepId in ({0}))  ", u, loanSearchViewModel.OptId);
            }

            return this.GetPageDataList<LoanInfoDto>(criteria);
        }

        /// <summary>
        ///获取信贷还款提醒信息Excle数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public CreditRemindListDto[] GetRepayRemindList(string RepayIdArray)
        {
            string SQL = @" SELECT 
 lo.OrderId,u.Name UserName,u.Phone UserPhone,dept.SignCity,dept.DepId , u.IDCard, 
                                p.ProductName,
                                (dept.SignCity+'-'+ CASE p.ProductId WHEN  6 THEN  'B' WHEN 7  THEN 'C' WHEN 8  THEN 'A'
                                                                     WHEN 31018  THEN 'D' WHEN 31019  THEN 'E'  WHEN 31020  THEN 'F'
                                                                     WHEN 31021  THEN 'G' WHEN 31022  THEN 'H'  WHEN 31023  THEN 'I'
                                                                     WHEN 31024 THEN 'J'
                                                                     ELSE '' END + '-'+ convert(nvarchar,lo.OrderId))  AS Contract 
FROM
T_OperaterInfo opt INNER JOIN T_LoanProductOrder lo ON opt.OptId =lo.CreateUserId
                                                      INNER JOIN T_UserInfo u  ON  u.UserId = lo.UserId    
                                                      INNER JOIN T_DepartmentInfo dept ON opt.DepId = dept.DepId 
                                                      INNER JOIN T_Product p ON   p.ProductId= CASE  lo.IsAccordanceProduct 
                                                            WHEN 1 then RIGHT(lo.ChangeProductName,LEN(lo.ChangeProductName)-CHARINDEX(',',lo.ChangeProductName))
                                                            ELSE  lo.ProductTypeId END
                                                             WHERE 1=1
";
            if (!String.IsNullOrEmpty(RepayIdArray))
            {
                SQL += " AND OrderId IN (" + RepayIdArray + ")";
            }

            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            var list = unitOfWorkContex.Context.Database.SqlQuery<CreditRemindListDto>(SQL).ToArray();
            return list;
        }
        /// <summary>
        ///  获取已经提醒数量和总数量
        /// </summary>
        /// <param name="isLongLoan"></param>
        /// <param name="signSities"></param>
        /// <param name="optId"></param>
        /// <returns></returns>
        public CreditCountDto GetIsRemindCount(int[] deptIds, int optId)
        {
            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            string condition = @" select count(*) As AllNum,count(case when IsRemind=1 then 1 else null end) As ShortNum from  (select mr.IsRemind from  T_Loan_MonthRepay mr INNER JOIN T_LoanProductOrder lo on mr.LoanOrderId=lo.OrderId
                                    INNER JOIN  T_OperaterInfo opt ON opt.OptId=lo.CreateUserId 
                                    INNER JOIN T_DepartmentInfo dept ON  dept.DepId=opt.DepId
                                    INNER JOIN T_UserInfo u ON u.UserId=lo.UserId 
                                    INNER JOIN T_Product p ON p.ProductId= CASE  lo.IsAccordanceProduct 
                                                          WHEN 1 then RIGHT(lo.ChangeProductName,LEN(lo.ChangeProductName)-CHARINDEX(',',lo.ChangeProductName))
                                                          ELSE  lo.ProductTypeId END";
            condition += @" where (lo.IsDeleted is null or  lo.IsDeleted=0) and DATEDIFF(DAY,GETDATE(),mr.RepayDate) between 0 and 10  ";
            //筛选 长期车贷 OR 短期车贷

            if (deptIds == null)
            {
                condition += ") as T_Count";
                return unitOfWorkContex.Context.Database.SqlQuery<CreditCountDto>(condition).FirstOrDefault();
            }
            else
            {
                string u = string.Join<int>(",", deptIds);
                condition += string.Format(" and dept.DepId in ({0}) ", u);
                condition += ") as T_Count";
            }

            return unitOfWorkContex.Context.Database.SqlQuery<CreditCountDto>(condition).FirstOrDefault();

        }
        /// <summary>
        ///获取信贷还款提醒信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public PagedList<CreditRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, int[] deptIds, int optId)
        {
            PageCriteria criteria = new PageCriteria();
            criteria.Fields = @" lo.OrderId,mr.IsRemind,mr.RepayId,opt.Name as OptName,
                                 dept.DepId as OptDeptId ,dept.SignCity,u.Name as UserName,
                                 u.Phone as UserPhone,u.IDCard,lo.DeptOptId,
                                 p.ProductName,lo.Amount,mr.MonthRepay";
            criteria.PageSize = pageSize;
            criteria.CurrentPage = pageNum;
            criteria.TableName = @" T_Loan_MonthRepay mr INNER JOIN T_LoanProductOrder lo on mr.LoanOrderId=lo.OrderId
                                    INNER JOIN  T_OperaterInfo opt ON opt.OptId=lo.CreateUserId 
                                    INNER JOIN T_DepartmentInfo dept ON  dept.DepId=opt.DepId
                                    INNER JOIN T_UserInfo u ON u.UserId=lo.UserId 
                                    INNER JOIN T_Product p ON p.ProductId= CASE  lo.IsAccordanceProduct 
                                                          WHEN 1 then RIGHT(lo.ChangeProductName,LEN(lo.ChangeProductName)-CHARINDEX(',',lo.ChangeProductName))
                                                          ELSE  lo.ProductTypeId END";
            criteria.PrimaryKey = "lo.OrderId";
            criteria.Condition += @" and (lo.IsDeleted is null or  lo.IsDeleted=0) and DATEDIFF(DAY,GETDATE(),mr.RepayDate) between 0 and 10 ";

            if (deptIds == null)
            {
                return this.GetPageDataList<CreditRemindListDto>(criteria);
            }

            else
            {
                string u = string.Join<int>(",", deptIds);
                criteria.Condition += string.Format(" and dept.DepId in ({0}) ", u);
            }

            return this.GetPageDataList<CreditRemindListDto>(criteria);
        }

        /// <summary>
        ///获取信贷逾期客户信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public PagedList<CreditOverdueListDto> GetPageOverdueList(int pageNum, int pageSize, int[] deptIds, int optId, int? collectTypeId)
        {
            PageCriteria criteria = new PageCriteria();
            criteria.Fields = @" lo.OrderId,lo.DeptOptId,lo.CollectStatus,u.Name as UserName,p.ProductName,lo.SignDate,dept.SignCity, 
                                 dept.DepId as OptDeptId, voi.OverduePrincipalSum,voi.FirstOverdueTime,voi.OverdueCount,voi.CreditStatus ";
            criteria.PageSize = pageSize;
            criteria.CurrentPage = pageNum;
            criteria.TableName = @" T_LoanProductOrder lo  INNER JOIN  T_OperaterInfo opt ON opt.OptId=lo.CreateUserId 
                                    INNER JOIN T_DepartmentInfo dept ON  dept.DepId=opt.DepId  
                                    INNER JOIN T_UserInfo u ON u.UserId=lo.UserId 
                                    INNER JOIN V_LoanOrderOverdueInfo voi ON voi.LoanOrderId=lo.OrderId
                                    INNER JOIN T_Product p ON p.ProductId= CASE  lo.IsAccordanceProduct 
                                                          WHEN 1 then RIGHT(lo.ChangeProductName,LEN(lo.ChangeProductName)-CHARINDEX(',',lo.ChangeProductName))
                                                          ELSE  lo.ProductTypeId END";
            criteria.PrimaryKey = "lo.OrderId";
            criteria.Condition += @" and (lo.IsDeleted is null or  lo.IsDeleted=0)";

            if (deptIds == null)
            {
                return this.GetPageDataList<CreditOverdueListDto>(criteria);
            }

            else
            {
                string u = string.Join<int>(",", deptIds);
                criteria.Condition += string.Format(" and ((lo.DeptOptId is null and dept.DepId in ({0})) or lo.DeptOptId ='{1}')", u, optId);
                criteria.Condition += string.Format(@" and voi.CreditStatus={0} ", collectTypeId == null ? -1 : collectTypeId);
            }

            return this.GetPageDataList<CreditOverdueListDto>(criteria);


        }

        /// <summary>
        ///获取信贷划扣审批信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public PagedList<CreditOverdueListDto> GetDeductApprovalList(int pageNum, int pageSize, int[] keyList)
        {
            PageCriteria criteria = new PageCriteria();
            criteria.Fields = @" lo.OrderId,lo.DeptOptId,u.Name as UserName,p.ProductName,lo.SignDate,dept.SignCity, 
                                 dept.DepId as OptDeptId,lo.Amount,
                                 voi.OverduePrincipalSum,voi.FirstOverdueTime,voi.OverdueCount,voi.CreditStatus ";
            criteria.PageSize = pageSize;
            criteria.CurrentPage = pageNum;
            criteria.TableName = @" T_LoanProductOrder lo  INNER JOIN  T_OperaterInfo opt ON opt.OptId=lo.CreateUserId 
                                    INNER JOIN T_DepartmentInfo dept ON  dept.DepId=opt.DepId  
                                    INNER JOIN T_UserInfo u ON u.UserId=lo.UserId 
                                    INNER JOIN V_LoanOrderOverdueInfo voi ON voi.LoanOrderId=lo.OrderId
                                    INNER JOIN T_Product p ON p.ProductId= CASE  lo.IsAccordanceProduct 
                                                          WHEN 1 then RIGHT(lo.ChangeProductName,LEN(lo.ChangeProductName)-CHARINDEX(',',lo.ChangeProductName))
                                                          ELSE  lo.ProductTypeId END";
            criteria.PrimaryKey = "lo.OrderId";
            criteria.Condition += @" and (lo.IsDeleted is null or  lo.IsDeleted=0)";

            //筛选 指定KeyList 列表
            if (keyList != null && keyList.Length > 0)
            {
                criteria.Condition += string.Format(" and lo.OrderId in ({0})", string.Join<int>(",", keyList)); ;
            }

            return this.GetPageDataList<CreditOverdueListDto>(criteria);
        }

        /// <summary>
        /// 获取批量划扣的当月信息分页
        /// </summary>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        public PagedList<CreditCriticalAmountListDto> GetCriticalAmountList(int pageNum, int pageSize, int orderId = 0)
        {
            PageCriteria criteria = new PageCriteria();
            criteria.Fields = @" lo.OrderId,u.Name,lm.MonthRepay,lm.[PeriodOrder],dept.SignCity ,lm.[RepayDate], 
                                p.ProductName,lo.Amount,lo.SignDate,
                                lo.DeductBankName,lo.DeductBranchBank,
                                ISNULL(ld.[DeductId],0) [DeductId],
								ISNULL(ld.Code,0) Code,
								ld.Result,
								ld.[OperateDate],
                                lo.DeductBankAccount,
                                (dept.SignCity+'-'+ CASE p.ProductId WHEN  6 THEN  'B' WHEN 7  THEN 'C' WHEN 8  THEN 'A'
                                                                     WHEN 31018  THEN 'D' WHEN 31019  THEN 'E'  WHEN 31020  THEN 'F'
                                                                     WHEN 31021  THEN 'G' WHEN 31022  THEN 'H'  WHEN 31023  THEN 'I'
                                                                     WHEN 31024 THEN 'J'
                                                                     ELSE '' END + '-'+ convert(nvarchar,lo.OrderId))  AS Contract ";
            criteria.PageSize = pageSize;
            criteria.CurrentPage = pageNum;
            criteria.TableName = @"  T_OperaterInfo opt INNER JOIN T_LoanProductOrder lo ON opt.OptId =lo.CreateUserId
                                                      INNER JOIN T_UserInfo u  ON  u.UserId = lo.UserId    
                                                      INNER JOIN T_DepartmentInfo dept ON opt.DepId = dept.DepId 
													  INNER JOIN T_Loan_MonthRepay lm ON lo.OrderId=lm.LoanOrderId
                                                      INNER JOIN T_Product p ON   p.ProductId= CASE  lo.IsAccordanceProduct 
                                                            WHEN 1 then RIGHT(lo.ChangeProductName,LEN(lo.ChangeProductName)-CHARINDEX(',',lo.ChangeProductName))
                                                            ELSE  lo.ProductTypeId END
													LEFT JOIN 
													(SELECT * FROM (  SELECT *,ROW_NUMBER() OVER (partition BY [LoanOrderId] ORDER BY [RepayPeriod] DESC) num  FROM [T_Loan_DeductProgress]) dl  WHERE dl.num=1) ld ON lo.OrderId =ld.[LoanOrderId] AND lm.[PeriodOrder]=ld.[RepayPeriod]  ";
            criteria.PrimaryKey = "lo.OrderId";
            criteria.Condition += @" and (lo.IsDeleted is null or  lo.IsDeleted=0)";

            string TodayTime = DateTime.Now.ToShortDateString();
            string LastMonthToday = DateTime.Now.AddMonths(-1).ToShortDateString();
            string RepayBetweenDate = "";
            RepayBetweenDate = "= '" + TodayTime + "'";
            RepayBetweenDate += " AND ([PeriodOrder]=1 OR [LoanOrderId] IN (SELECT [LoanOrderId] FROM [T_Loan_MonthRepay] WHERE [RepayDate] = '";
            RepayBetweenDate += LastMonthToday + "' AND  ([IsDeductSucess] is null OR IsDeductSucess=1)))";

            criteria.Condition += "AND lm.[RepayId] IN  (SELECT [RepayId] FROM [T_Loan_MonthRepay] WHERE [RepayDate] " + RepayBetweenDate + " AND  [IsDeductSucess] is null)";
            //筛选 指定KeyList 列表
            if (orderId > 0)
            {
                criteria.Condition += " AND lo.OrderId =" + orderId;
            }

            return this.GetPageDataList<CreditCriticalAmountListDto>(criteria);
        }

        /// <summary>
        /// 获取批量划扣的当月信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<CreditCriticalAmountListDto> GetCriticalAmountList(int orderId = 0)
        {
            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            string condition = @" SELECT 
                                lo.OrderId,lm.MonthRepay,lm.[PeriodOrder],lm.[RepayDate], 
                                lo.Amount,
                                ISNULL(ld.[DeductId],0) [DeductId],lm.[RepayId],
								ISNULL(ld.Code,0) Code
								 FROM  T_OperaterInfo opt INNER JOIN T_LoanProductOrder lo ON opt.OptId =lo.CreateUserId
                                                     INNER JOIN T_Loan_MonthRepay lm ON lo.OrderId=lm.LoanOrderId
                                                  	LEFT JOIN 
													(SELECT * FROM (  SELECT *,ROW_NUMBER() OVER (partition BY [LoanOrderId] ORDER BY [RepayPeriod] DESC) num  FROM [T_Loan_DeductProgress]) dl  WHERE dl.num=1) ld ON lo.OrderId =ld.[LoanOrderId] AND lm.[PeriodOrder]=ld.[RepayPeriod]  
													where 1=1";
            condition += @" and (lo.IsDeleted is null or  lo.IsDeleted=0) ";

            string TodayTime = DateTime.Now.ToShortDateString();
            string LastMonthToday = DateTime.Now.AddMonths(-1).ToShortDateString();
            string RepayBetweenDate = "= '" + TodayTime + "'";
            RepayBetweenDate += " AND ([PeriodOrder]=1 OR [LoanOrderId] IN (SELECT [LoanOrderId] FROM [T_Loan_MonthRepay] WHERE [RepayDate] = '";
            RepayBetweenDate += LastMonthToday + "' AND  ([IsDeductSucess] is null OR IsDeductSucess=1)))";

            condition += " AND lm.[RepayId] IN  (SELECT [RepayId] FROM [T_Loan_MonthRepay] WHERE [RepayDate] " + RepayBetweenDate + " AND  [IsDeductSucess] is null)";
            condition += "   AND( ld.Code IS NULL OR ld.Code ='40')";
            //筛选 指定KeyList 列表
            if (orderId > 0)
            {
                condition += " AND lo.OrderId =" + orderId;
            }
            return unitOfWorkContex.Context.Database.SqlQuery<CreditCriticalAmountListDto>(condition).ToList();
        }

        /// <summary>
        /// 获取信贷财务信息导出数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<CreditFinancialExportExcleDto> GetCreditFinancialExportExcleList(CreditFinancialExportExcleRequest model)
        {
            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            string condition = @"  SELECT DISTINCT
	                           lo.[OrderId] ,
	                           dept.DepId,
	                           dept.SignCity ,
	                           (dept.SignCity+'-'+ CASE p.ProductId WHEN  6 THEN  'B' WHEN 7  THEN 'C' WHEN 8  THEN 'A'
                                                                                             WHEN 31018  THEN 'D' WHEN 31019  THEN 'E'  WHEN 31020  THEN 'F'
                                                                                             WHEN 31021  THEN 'G' WHEN 31022  THEN 'H'  WHEN 31023  THEN 'I'
                                                                                             WHEN 31024 THEN 'J'
                                                                                             ELSE '' END + '-'+ convert(nvarchar,lo.OrderId))  AS Contract  ,
	                            u.Name , u.IDCard , p.ProductName ,lo.Purpose,lo.DeductBankAccount ,	
	                            lo.DeductBankName ,			lo.DeductBranchBank ,		
	                          lo.SignDate ,lo.ApplyAmount,
	                           lo.Amount ,
                              lo.[Term] ,
	                          lo.RepayPerMonth
	                           ,lo.[DeductDate]   
	                        ,u.Phone,
	                        lo.IsCoborrowLoan,
	                        lo.[CoborrowName],
	                        lo.[CoborrowIDCard],
	                        lo.[IsExtension],
							lp.ActualDeductDate ActualLenderDate
	                        ,lo.[TeamManager] 
                              ,lo.[CustomerManager] 
                              ,lo.[ContractEndDate] 
                            FROM 
	                        T_OperaterInfo opt INNER JOIN T_LoanProductOrder lo ON opt.OptId =lo.CreateUserId
							LEFT JOIN T_Loan_PayProgress lp ON lo.OrderId=lp.LoanOrderId
                            INNER JOIN T_UserInfo u  ON  u.UserId = lo.UserId    
                            INNER JOIN T_DepartmentInfo dept ON opt.DepId = dept.DepId 
                            INNER JOIN T_Product p ON   p.ProductId= CASE  lo.IsAccordanceProduct 
                            WHEN 1 then RIGHT(lo.ChangeProductName,LEN(lo.ChangeProductName)-CHARINDEX(',',lo.ChangeProductName))
                            ELSE  lo.ProductTypeId END
                            ";
            condition += @" and (lo.IsDeleted is null or  lo.IsDeleted=0) ";

            if (model.CityName.HasValue && model.CityName != 0)
            {
                condition += " and dept.DepId=" + model.CityName;
            }
            if (model.ProductName.HasValue && model.ProductName != 0)
            {
                condition += " and p.ProductId=" + model.ProductName;
            }
            if (model.ContractDataBegin.HasValue)
            {
                condition += " and lo.ContractStartDate >='" + model.ContractDataBegin.Value.ToShortDateString() + "'";
            }
            if (model.ContractDataEnd.HasValue)
            {
                condition += " and lo.ContractStartDate<='" + model.ContractDataEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
            }
            //if (model.TeamName.HasValue && model.TeamName != 0)
            //{
            //    condition += " and fac.GroupNumber='" + model.TeamName;
            //}
            if (model.LoansDataBegin.HasValue)
            {
                condition += " and lp.ActualDeductDate>='" + model.LoansDataBegin.Value.ToShortDateString() + "'";
            }
            if (model.LoansDataEnd.HasValue)
            {
                condition += " and lp.ActualDeductDate<='" + model.LoansDataEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            return unitOfWorkContex.Context.Database.SqlQuery<CreditFinancialExportExcleDto>(condition).ToList();
        }


        /// <summary>
        ///获取违约逾期报表
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public List<CreditOverdueExcelDto> GetOverdueExcelList(CreditOverdueSearchRequest overdueSearchRequest)
        {
            string mr = "0";
            if (overdueSearchRequest.Status == 1)
            {
                mr = @"(select * from  T_Loan_MonthRepay where IsDeductSucess=1 and ( cast(convert(varchar(10),RepayDate,120) as datetime) +1)<ActualDeductDate" + (overdueSearchRequest.RepayDate == null ? " " : (" and cast(convert(varchar(10),RepayDate,120) as datetime)='" + overdueSearchRequest.RepayDate.Value.ToShortDateString() + "'"));
                mr += @") mr";
            }
            else if (overdueSearchRequest.Status == 2)
            {
                mr = @"(select * from  T_Loan_MonthRepay where (IsDeductSucess=0 or IsDeductSucess is null) and ( cast(convert(varchar(10),RepayDate,120) as datetime) +1)<ActualDeductDate and DeductOverduePenalty !=0" + (overdueSearchRequest.RepayDate == null ? " " : (" and cast(convert(varchar(10),RepayDate,120) as datetime)='" + overdueSearchRequest.RepayDate.Value.ToShortDateString() + "'"));
                mr += @") mr";
            }
            else if (overdueSearchRequest.Status == 0)
            {
                mr = @"(select * from  T_Loan_MonthRepay where (IsDeductSucess=0 or IsDeductSucess is null) and ( cast(convert(varchar(10),RepayDate,120) as datetime) +1)<GetDate() and (DeductOverduePenalty =0 or DeductOverduePenalty is NULL)" + (overdueSearchRequest.RepayDate == null ? " " : (" and cast(convert(varchar(10),RepayDate,120) as datetime)='" + overdueSearchRequest.RepayDate.Value.ToShortDateString() + "'"));
                mr += @") mr";
            }
            string condition = @"select bi.BankCode, voi.CreditStatus,mr.PeriodOrder,u.Phone UserPhone, dept.DepId,mr.MonthRate, mr.OverduePenalty,DATEDIFF(DAY,mr.RepayDate,GETDATE()) as OverDueDays,mr.DailyPenalty,  mr.RepayDate ,GETDATE() as Date,mr.ActualDeductAmount, mr.ActualDeductDate,
                                (dept.SignCity+'-'+ CASE pt.ProductId WHEN  6 THEN  'B' WHEN 7  THEN 'C' WHEN 8  THEN 'A'
                                                                     WHEN 31018  THEN 'D' WHEN 31019  THEN 'E'  WHEN 31020  THEN 'F'
                                                                     WHEN 31021  THEN 'G' WHEN 31022  THEN 'H'  WHEN 31023  THEN 'I'
                                                                     WHEN 31024 THEN 'J'
                                                                     ELSE '' END + '-'+ convert(nvarchar,p.OrderId))  AS Contract ,p.SignDate,u.Name UserName,u.IdCard,
                                p.DeductBankAccount,p.DeductBranchBank,p.Amount,pt.ProductName,
                                mr.ToalPeriod,mr.MonthRepayPrincipal,DAY( mr.RepayDate) as RepayDay ,mrD.FirstRepaymentDate,mrD.LastRepaymentDate,
                                mr.MonthRepay,mr.ActualDeductAmount,mr.ActualDeductDate,mr.IsDeductSucess, 
                                (case when  mrC.IsDeductTerm is  null then 0 else  mrC.IsDeductTerm end) as IsDeductTerm,
                               (mr.ToalPeriod- (case when  mrC.IsDeductTerm is  null then 0 else  mrC.IsDeductTerm end)) as NotDeductTerm from T_LoanProductOrder p
                                    INNER JOIN  T_OperaterInfo opt ON opt.OptId=p.CreateUserId 
								   INNER JOIN T_DepartmentInfo dept ON  dept.DepId=opt.DepId  
                                    INNER JOIN T_UserInfo u ON u.UserId=p.UserId 
									 INNER JOIN T_Product pt ON pt.ProductId= CASE  p.IsAccordanceProduct 
                                                          WHEN 1 then RIGHT(p.ChangeProductName,LEN(p.ChangeProductName)-CHARINDEX(',',p.ChangeProductName))
                                                          ELSE  p.ProductTypeId END

                                    INNER JOIN V_LoanOrderOverdueInfo voi ON voi.LoanOrderId=p.OrderId
                                    left join T_BankInfo bi on bi.BankName=p.DeductBankName
									inner join " + mr + @" on p.OrderId=mr.LoanOrderId
                                    left join (select Min(RepayDate)as FirstRepaymentDate,MAX(RepayDate) as LastRepaymentDate ,LoanOrderId   from T_Loan_MonthRepay group by LoanOrderId ) mrD on mrD.LoanOrderId=mr.LoanOrderId
									left  join(select COUNT(*) as IsDeductTerm,LoanOrderId  from  T_Loan_MonthRepay where IsDeductSucess=1 group by LoanOrderId) mrC on mrC.LoanOrderId=mr.LoanOrderId
									 where  (p.IsDeleted=0 or p.IsDeleted is null)";
            if (overdueSearchRequest.DeptId != null)
            {
                condition += string.Format(" and dept.DepId={0} ", overdueSearchRequest.DeptId);
            }
            if (overdueSearchRequest.LoanTypeId != null)
            {
                condition += string.Format(" and pt.ProductId={0} ", overdueSearchRequest.LoanTypeId);
            }
            if (overdueSearchRequest.CollectStatus == 1)
            {
                condition += string.Format(" and p.CollectStatus in (1,2)");
            }
            else if (overdueSearchRequest.CollectStatus == 2)
            {
                condition += string.Format(" and p.CollectStatus not in (1,2)");
            }
            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            var list = unitOfWorkContex.Context.Database.SqlQuery<CreditOverdueExcelDto>(condition).ToList();
            return list;
        }
    }

}
