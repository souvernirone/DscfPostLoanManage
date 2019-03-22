using Dscf.CarLoan.Dao.Context;
using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.Common.Dao.Context;
using Dscf.Common.Dao.Implement;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Dscf.CarLoan.Dao.Implement
{
    //贷款订单表
    public class LoanProductOrderRepository : RepositoryBase<LoanProductOrder>, ILoanProductOrderRepository
    {
        /// <summary>
        /// 车贷借款信息分页
        /// </summary>
        /// <param name="loanSearchaRequest"></param>
        /// <returns></returns>
        public PagedList<LoanProductOrderDto> SelectLoanProductOrderList(LoanSearchaRequest loanSearchaRequest)
        {
            PageCriteria criteria = new PageCriteria();

            criteria.Condition += string.Format(" and (p.IsDelete={0} or p.IsDelete is null) ", 0);
            criteria.Condition += "  and p.StatusId in (902,3010) and p.ProductOrderId>=48076 ";

            criteria.Fields = @"p.ProductOrderId as OrderId,p.DeptOptId, p.UserId,l.UserName as Name,l.IDCard,s.CovenantNo as Contract,l.signCity,s.SigningDate as SignDate,p.Amount,cc.CarLoanTypeName as ProductName ";
            criteria.PageSize = loanSearchaRequest.PageSize;
            criteria.CurrentPage = loanSearchaRequest.PageNum;
            criteria.TableName = @" T_LoanProductOrder p 
                                    inner join T_LobbyInfo l on p.ProductOrderId=l.NewOrderId 
                                    inner join T_SignedInfo s on s.LobbyId=l.LobbyId 
                                    inner join T_FaceTrialInfo f on l.FaceTrialId=f.FaceTrailId 
                                    inner join T_CarLoanConfig cc on cc.LoanTypeId=f.ProductTypeId ";
            criteria.PrimaryKey = "p.ProductOrderId";
            criteria.Sort = " s.SigningDate desc ";

            //姓名
            if (!string.IsNullOrEmpty(loanSearchaRequest.Name))
            {
                criteria.Condition += string.Format(" and l.UserName like '%{0}%' ", loanSearchaRequest.Name);
            }
            //身份证号
            if (!string.IsNullOrEmpty(loanSearchaRequest.IdCard))
            {
                criteria.Condition += string.Format(" and l.IDCard='{0}' ", loanSearchaRequest.IdCard);
            }
            //城市
            if (!string.IsNullOrEmpty(loanSearchaRequest.City))
            {
                criteria.Condition += string.Format(" and l.signCity like '%{0}%' ", loanSearchaRequest.City);
            }
            //合同编号
            if (!string.IsNullOrEmpty(loanSearchaRequest.ContractNo))
            {
                criteria.Condition += string.Format(" and s.CovenantNo='{0}' ", loanSearchaRequest.ContractNo);
            }
            //产品类型
            if (!string.IsNullOrEmpty(loanSearchaRequest.ProductName))
            {
                criteria.Condition += string.Format(" and cc.CarLoanTypeName like '%{0}%' ", loanSearchaRequest.ProductName);
            }
            //签约时间
            if (!string.IsNullOrEmpty(loanSearchaRequest.SignTimeFrom))
            {
                criteria.Condition += string.Format(" and s.SigningDate>='{0}' ", loanSearchaRequest.SignTimeFrom);
            }
            if (!string.IsNullOrEmpty(loanSearchaRequest.SignTimeTo))
            {
                criteria.Condition += string.Format(" and s.SigningDate<='{0}' ", loanSearchaRequest.SignTimeTo);
            }
            if (loanSearchaRequest.SignSities == null)
            {
                return this.GetPageDataList<LoanProductOrderDto>(criteria);
            }
            else
            {
                for (int i = 0; i < loanSearchaRequest.SignSities.Length; i++)
                {
                    loanSearchaRequest.SignSities[i] = "'" + loanSearchaRequest.SignSities[i] + "'";
                }
                string u = string.Join<string>(",", loanSearchaRequest.SignSities);
                criteria.Condition += string.Format(" and ((p.DeptOptId is null  and  l.signCity in ({0}))or p.DeptOptId ='{1}') ", u, loanSearchaRequest.OptId);
            }

            return this.GetPageDataList<LoanProductOrderDto>(criteria);
        }

        /// <summary>
        /// 根据订单编号查询车贷借款详细信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public LoanProductOrderDto GetLoanProductOrderByOrderId(int orderId)
        {
            string condition = @" select p.ProductOrderId as OrderId,p.UserId, s.SigningDate as SignDate,p.Amount,
                               p.Term,l.UserName as Name,u.Phone,l.IDCard,s.CovenantNo as Contract,l.signCity,cc.CarLoanTypeName as ProductName,
                               l.LobbyId,l.LoanExtensionId as LobbyLoanExtensionId,ub.BankName,ub.BankCard,ub.SubBranchName 
                               from T_LoanProductOrder p 
                               inner join T_UserInfo u on u.UserInfoId=p.UserId 
                               inner join (select * from T_UserBankInfo where isdelete=0 and IsEnable=1)ub on u.UserInfoId=ub.UserId 
                               inner join T_LobbyInfo l on p.ProductOrderId=l.NewOrderId 
                               inner join T_SignedInfo s on s.LobbyId=l.LobbyId and l.SignedId=s.SignId and s.UserBankInfoId=ub.UserBankId 
                               inner join T_FaceTrialInfo f on l.FaceTrialId=f.FaceTrailId 
                               inner join T_CarLoanConfig cc on cc.LoanTypeId=f.ProductTypeId 
                               where p.ProductOrderId= {0}";

            string sql = string.Format(condition, orderId);

            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            var model = unitOfWorkContex.Context.Database.SqlQuery<LoanProductOrderDto>(sql).FirstOrDefault();

            return model;
        }

        /// <summary>
        /// 根据订单编号查询车贷借款详细信息附加展期
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public LoanProductExtensionOrderDto GetLoanProductExtensionOrderByOrderId(int orderId)
        {
            string condition = @" select p.ProductOrderId as OrderId,p.UserId, s.SigningDate as SignDate,p.Amount,
                               p.Term,l.UserName as Name,l.IDCard,s.CovenantNo as Contract,l.signCity,cc.CarLoanTypeName as ProductName,
                               l.LobbyId,l.LoanExtensionId as LobbyLoanExtensionId,ub.BankName,ub.BankCard,ub.SubBranchName ,tc.ExtensionAmount,
							   tc.PreAmount,tc.DeratingAmount,tc.FeeAmount,tc.TotalAmount,tc.BreachofcontractAmount,tc.PenaltyInterest,tc.Fee,
							   tc.Interest,tc.AuditFee,tc.ServiceFee,tc.ConsultingFee,tc.ReBreachofcontractAmount,tc.RePenaltyInterest,tc.ReFee
                               from T_LoanProductOrder p 
                               inner join T_UserInfo u on u.UserInfoId=p.UserId 
                               inner join (select * from T_UserBankInfo where isdelete=0 and IsEnable=1)ub on u.UserInfoId=ub.UserId 
                               inner join T_LobbyInfo l on p.ProductOrderId=l.NewOrderId 
                               inner join T_SignedInfo s on s.LobbyId=l.LobbyId and l.SignedId=s.SignId and s.UserBankInfoId=ub.UserBankId 
                               inner join T_FaceTrialInfo f on l.FaceTrialId=f.FaceTrailId 
                               inner join T_CarLoanConfig cc on cc.LoanTypeId=f.ProductTypeId 
							   left join T_CarLoanExtension tc on tc.NewProductOrderId=p.ProductOrderId
                               where p.ProductOrderId= {0}";

            string sql = string.Format(condition, orderId);

            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            var model = unitOfWorkContex.Context.Database.SqlQuery<LoanProductExtensionOrderDto>(sql).FirstOrDefault();

            return model;
        }
        /// <summary>
        ///获取车贷还款提醒Excle数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public List<CarRemindListDto> GetRepayRemindList(string RepayIdArray)
        {
            string SQL = @"SELECT  lo.ProductOrderId as OrderId,mr.IsRemind,mr.RepayId,u.Name as UserName,
                                 u.Phone as UserPhone,lo.OperateId,lobby.SignCity,
                                 p.CarLoanTypeName as ProductName,p.IsCanExtension,
                                 dict.DictMemo as RemindText,
                                 (CASE WHEN (p.IsCanExtension is null or  p.IsCanExtension=0) THEN 0 
                                       WHEN ( mr.IsRemind in (2,3) ) THEN 0 
                                       WHEN (p.IsCanExtension=1 AND cep.ApplyCount>0)  THEN 0                             
                                       ELSE  1  END) as IsAllowExtension,
                                (CASE WHEN  (p.IsCanExtension is null or  p.IsCanExtension=0)  THEN 1
                                      WHEN   carE.CarExtCount>0  THEN 0   
									  WHEN  cep.ApplyCount>0 and  cep.ApplyDayCount<=3   THEN 0
                                      ELSE 1 END) as IsAllowRemain 
FROM  T_LoanMonthRepay mr INNER JOIN T_LoanProductOrder lo on mr.LoanOrderId=lo.ProductOrderId
                                    INNER JOIN T_UserInfo u ON u.UserInfoId=lo.UserId 
                                    INNER JOIN T_LobbyInfo lobby ON lo.ProductOrderId=lobby.NewOrderId
                                    INNER JOIN T_FaceTrialInfo ft ON ft.FaceTrailId=lobby.FaceTrialId
                                    INNER JOIN T_CarLoanConfig p ON p.LoanTypeId= ft.ProductTypeId
                                    LEFT JOIN (SELECT * FROM T_Dictionary where DictKey='CarLoanRemindMark') as dict ON dict.DictValue=mr.IsRemind 
                                    LEFT JOIN (SELECT LoanProductOrerId,COUNT(*) as ApplyCount,MAX(CreateTime) as CreateTime ,DATEDIFF(day,MAX(CreateTime),getdate()) as ApplyDayCount from T_CarLoanExtensionApply where IsDelete=0 and IsEnable=1  group by LoanProductOrerId) cep on cep.LoanProductOrerId=lo.ProductOrderId  
                                    LEFT JOIN (SELECT LoanProductOrderId,COUNT(*) as CarExtCount,DATEDIFF(day,MAX(CreateTime),getdate()) as xDayCount from T_CarLoanExtension where IsDelete=0 and IsEnable=1 group by LoanProductOrderId) carE on carE.LoanProductOrderId=lo.ProductOrderId 
WHERE 1=1
";
            if (!String.IsNullOrEmpty(RepayIdArray))
            {
                SQL += " AND RepayId IN (" + RepayIdArray + ")";
            }
            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            var list = unitOfWorkContex.Context.Database.SqlQuery<CarRemindListDto>(SQL).ToList();
            return list;
        }
        /// <summary>
        /// 获取已经提醒的数量和总数量
        /// </summary>
        /// <param name="isLongLoan"></param>
        /// <param name="signSities"></param>
        /// <param name="optId"></param>
        /// <returns></returns>
        public CarCountDto GetIsRemindCount(bool isLongLoan, string[] signSities, int optId)
        {
            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            string condition = @" select count(*) As AllNum,count(case when IsRemind>=1 then 1 else null end) As ShortNum from  (select mr.IsRemind from T_LoanMonthRepay mr INNER JOIN T_LoanProductOrder lo on mr.LoanOrderId=lo.ProductOrderId
                                    INNER JOIN T_UserInfo u ON u.UserInfoId=lo.UserId 
                                    INNER JOIN T_LobbyInfo lobby ON lo.ProductOrderId=lobby.NewOrderId
                                    INNER JOIN T_FaceTrialInfo ft ON ft.FaceTrailId=lobby.FaceTrialId
                                    INNER JOIN T_CarLoanConfig p ON p.LoanTypeId= ft.ProductTypeId
                                    LEFT JOIN (SELECT * FROM T_Dictionary where DictKey='CarLoanRemindMark') as dict ON dict.DictValue=mr.IsRemind 
                                    LEFT JOIN (SELECT LoanProductOrerId,COUNT(*) as ApplyCount,MAX(CreateTime) as CreateTime ,DATEDIFF(day,MAX(CreateTime),
                                    getdate()) as ApplyDayCount from T_CarLoanExtensionApply where IsDelete=0 and IsEnable=1  group by LoanProductOrerId) cep on cep.LoanProductOrerId=lo.ProductOrderId  
                                    LEFT JOIN (SELECT LoanProductOrderId,COUNT(*) as CarExtCount,DATEDIFF(day,MAX(CreateTime),getdate()) as xDayCount from T_CarLoanExtension where IsDelete=0 and IsEnable=1 group by LoanProductOrderId) carE on carE.LoanProductOrderId=lo.ProductOrderId";
            condition += @" where (lo.IsDelete is null or  lo.IsDelete=0) and DATEDIFF(DAY,GETDATE(),mr.RepayDate) between 0 and 10  ";
            //筛选 长期车贷 OR 短期车贷

            condition += isLongLoan ? " and p.IsLongLoan=1" : " and p.IsLongLoan=0 ";
            condition += "  and lo.StatusId in (902,3010) and lo.ProductOrderId>=48076 ";

            if (signSities == null)
            {
                condition += ") as T_Count";
                return unitOfWorkContex.Context.Database.SqlQuery<CarCountDto>(condition).FirstOrDefault();
            }
            else
            {
                for (int i = 0; i < signSities.Length; i++)
                {
                    signSities[i] = "'" + signSities[i] + "'";
                }
                string u = string.Join<string>(",", signSities);
                condition += string.Format(" and  lobby.signCity in ({0}) ", u);
                condition += ") as T_Count";
            }

            return unitOfWorkContex.Context.Database.SqlQuery<CarCountDto>(condition).FirstOrDefault();

        }
        //}
        /// <summary>
        /// 车贷还款提醒信息分页
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isLongLoan"></param>
        /// <returns></returns>
        public PagedList<CarRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, bool isLongLoan, string[] signSities, int optId)
        {
            //如果是押车或者GPS30天则是可进行展期的，展期申请成功后灰掉“展”，填写申请展期时却放弃展期则灰掉“展”
            //如果展期申请后营业部处理了，则灰掉“展”，亮“提”，如果展期超过3天则灰掉“展”和“提”
            PageCriteria criteria = new PageCriteria();
            criteria.Fields = @" lo.ProductOrderId as OrderId,mr.IsRemind,mr.RemindDate,mr.RepayId,u.Name as UserName,
                                 u.Phone as UserPhone,u.IDCard,lo.OperateId,lobby.SignCity,lo.DeptOptId,
                                 p.CarLoanTypeName as ProductName,p.IsCanExtension,lo.Amount,mr.MonthRepay,
                                 dict.DictMemo as RemindText,cep.ApplyCount,cep.ApplyDayCount,carE.CarExtCount,
                                 (CASE WHEN (p.IsCanExtension is null or  p.IsCanExtension=0) THEN 0 
                                       WHEN ( mr.IsRemind in (2) ) THEN 0 
                                       WHEN ( mr.IsRemind in (3) and p.IsCanExtension=1 and mr.GiveupExtension>=2 ) THEN 0 
                                       WHEN (p.IsCanExtension=1 AND cep.ApplyCount>0)  THEN 0                             
                                       ELSE  1  END) as IsAllowExtension,
                                (CASE WHEN  (p.IsCanExtension is null or  p.IsCanExtension=0)  THEN 1
                                      WHEN   carE.CarExtCount>0  THEN 0   
									  WHEN  cep.ApplyCount>0 and  cep.ApplyDayCount<=3   THEN 0
                                      ELSE 1 END) as IsAllowRemain ";
            criteria.PageSize = pageSize;
            criteria.CurrentPage = pageNum;
            criteria.TableName = @" T_LoanMonthRepay mr INNER JOIN T_LoanProductOrder lo on mr.LoanOrderId=lo.ProductOrderId
                                    INNER JOIN T_UserInfo u ON u.UserInfoId=lo.UserId 
                                    INNER JOIN T_LobbyInfo lobby ON lo.ProductOrderId=lobby.NewOrderId
                                    INNER JOIN T_FaceTrialInfo ft ON ft.FaceTrailId=lobby.FaceTrialId
                                    INNER JOIN T_CarLoanConfig p ON p.LoanTypeId= ft.ProductTypeId
                                    LEFT JOIN (SELECT * FROM T_Dictionary where DictKey='CarLoanRemindMark') as dict ON dict.DictValue=mr.IsRemind 
                                    LEFT JOIN (SELECT LoanProductOrerId,COUNT(*) as ApplyCount,MAX(CreateTime) as CreateTime ,DATEDIFF(day,MAX(CreateTime),getdate()) as ApplyDayCount from T_CarLoanExtensionApply where IsDelete=0 and IsEnable=1  group by LoanProductOrerId) cep on cep.LoanProductOrerId=lo.ProductOrderId  
                                    LEFT JOIN (SELECT LoanProductOrderId,COUNT(*) as CarExtCount,DATEDIFF(day,MAX(CreateTime),getdate()) as xDayCount from T_CarLoanExtension where IsDelete=0 and IsEnable=1 group by LoanProductOrderId) carE on carE.LoanProductOrderId=lo.ProductOrderId ";
            criteria.PrimaryKey = "lo.ProductOrderId";
            criteria.Condition += @" and (lo.IsDelete is null or  lo.IsDelete=0) 
                                     and DATEDIFF(DAY,GETDATE(),mr.RepayDate) between 0 and 10 ";
            //筛选 长期车贷 OR 短期车贷

            criteria.Condition += isLongLoan ? " and p.IsLongLoan=1" : " and p.IsLongLoan=0";

            criteria.Condition += "  and lo.StatusId in (902,3010) and lo.ProductOrderId>=48076 ";
            if (signSities == null)
            {
                return this.GetPageDataList<CarRemindListDto>(criteria);
            }
            else
            {
                for (int i = 0; i < signSities.Length; i++)
                {
                    signSities[i] = "'" + signSities[i] + "'";
                }
                string u = string.Join<string>(",", signSities);
                criteria.Condition += string.Format(" and  lobby.signCity in ({0}) ", u);
            }
            return this.GetPageDataList<CarRemindListDto>(criteria);

        }

        /// <summary>
        /// 根据订单编号查询车贷借款详细信息及展期（车贷月还提醒）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public LoanProductOrderDto GetCarLoanRemindByOrderId(int orderId)
        {
            string condition = @" select p.ProductOrderId as OrderId,p.UserId, s.SigningDate as SignDate,p.Amount,p.Term,
                                  l.UserName as Name,l.IDCard,s.CovenantNo as Contract,ub.BankName,ub.BankCard,ub.SubBranchName, p.Term,work.CompanyName,work.CompanyTel,work.CertifyName,work.CertifyRelation,work.CertifyTel,work.CertifyName2,work.CertifyRelation2,work.CertifyTel2 
                                 from T_LoanProductOrder p inner join T_UserInfo u on u.UserInfoId=p.UserId 
                                 inner join T_UserWorkInfo work on u.UserInfoId=work.UserId  
                                 inner join (select * from T_UserBankInfo where isdelete=0 and IsEnable=1)ub on u.UserInfoId=ub.UserId
                                 inner join T_LobbyInfo l on p.ProductOrderId=l.NewOrderId           
                                 inner join T_SignedInfo s on s.LobbyId=l.LobbyId and l.SignedId=s.SignId and s.UserBankInfoId=ub.UserBankId 
                                 where p.ProductOrderId= {0} ";

            condition = string.Format(condition, orderId);

            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            var model = unitOfWorkContex.Context.Database.SqlQuery<LoanProductOrderDto>(condition).FirstOrDefault();

            return model;
        }


        /// <summary>
        /// 获取车贷逾期客户信息分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isLongLoan"></param>
        /// <returns></returns>
        public PagedList<CarOverdueListDto> GetPageOverdueList(int pageNum, int pageSize, bool? isLongLoan, string[] signSities, int optId, int? collectTypeId)
        {
            PageCriteria criteria = new PageCriteria();

            criteria.Condition = string.Format(" and p.StatusId in (902,3010) and (p.IsDelete={0} or p.IsDelete is null) ", 0);
            //筛选 长期车贷 OR 短期车贷
            if (isLongLoan.HasValue)
            {
                criteria.Condition += isLongLoan.Value ? " and cc.IsLongLoan=1" : " and cc.IsLongLoan=0";
            }

            criteria.Fields = @" p.ProductOrderId as OrderId,p.CollectStatus , p.DeptOptId,p.SignDate,p.OperateId,u.Name as UserName,
                                 cc.CarLoanTypeName as ProductName,vcl.FirstOverdueTime,vcl.OverdueCount,l.signCity,
                                 vcl.OverduePrincipalSum,vcl.CarLoanStatus,cc.IsCanExtension,
                                 (select count(*) from T_CarLoanExtensionApply  where  IsDelete=0 and IsEnable=1 and LoanProductOrerId=p.ProductOrderId) as ExtensionApplyCount,
                                  p.ReconsiderationStatusId ";
            criteria.PageSize = pageSize;
            criteria.CurrentPage = pageNum;
            criteria.TableName = @" T_LoanProductOrder p 
                                    inner join T_UserInfo u on u.UserInfoId = p.UserId 
                                    inner join T_LobbyInfo l on p.ProductOrderId=l.NewOrderId 
                                    inner join T_FaceTrialInfo f on l.FaceTrialId=f.FaceTrailId 
                                    inner join T_CarLoanConfig cc on cc.LoanTypeId=f.ProductTypeId
                                    inner join V_CarLoanOrderOverdueInfo vcl on vcl.LoanOrderId=p.ProductOrderId ";
            criteria.PrimaryKey = " p.ProductOrderId ";

            if (signSities == null)
            {
                return this.GetPageDataList<CarOverdueListDto>(criteria);
            }
            else
            {
                for (int i = 0; i < signSities.Length; i++)
                {
                    signSities[i] = "'" + signSities[i] + "'";
                }
                string u = string.Join<string>(",", signSities);
                criteria.Condition += string.Format("and ((p.DeptOptId is null and  l.signCity in ({0}))or p.DeptOptId ='{1}') ", u, optId);

                criteria.Condition += string.Format(@" and vcl.CarLoanStatus={0} ", collectTypeId == null ? -1 : collectTypeId);
            }
            return this.GetPageDataList<CarOverdueListDto>(criteria);
        }

        public PagedList<CarOverdueListDto> GetPageDeductApprovalList(int pageNum, int pageSize, int[] keyList)
        {

            PageCriteria criteria = new PageCriteria();

            criteria.Condition = string.Format(" and (p.IsDelete={0} or p.IsDelete is null) ", 0);

            //筛选 指定KeyList 列表
            if (keyList != null && keyList.Length > 0)
            {
                criteria.Condition += string.Format(" and p.ProductOrderId in ({0})", string.Join<int>(",", keyList)); ;
            }

            criteria.Fields = @" p.ProductOrderId as OrderId,p.DeptOptId,p.SignDate,p.OperateId,u.Name as UserName,p.Amount,
                                 cc.CarLoanTypeName as ProductName,vcl.FirstOverdueTime,vcl.OverdueCount,l.CreateTime as LobbyTime,p.IsExtension,
                                 vcl.OverduePrincipalSum,vcl.CarLoanStatus,cc.IsCanExtension,f.LicensePlate ";
            criteria.PageSize = pageSize;
            criteria.CurrentPage = pageNum;
            criteria.TableName = @" T_LoanProductOrder p 
                                    inner join T_UserInfo u on u.UserInfoId = p.UserId 
                                    inner join T_LobbyInfo l on p.ProductOrderId=l.NewOrderId 
                                    inner join T_FaceTrialInfo f on l.FaceTrialId=f.FaceTrailId 
                                    inner join T_CarLoanConfig cc on cc.LoanTypeId=f.ProductTypeId
                                    inner join V_CarLoanOrderOverdueInfo vcl on vcl.LoanOrderId=p.ProductOrderId ";
            criteria.PrimaryKey = " p.ProductOrderId ";

            return this.GetPageDataList<CarOverdueListDto>(criteria);
        }
        public PagedList<CarLoanBatchDeductDto> GetPageCarLoanBatchDeductList(int pageNum, int pageSize)
        {

            PageCriteria criteria = new PageCriteria();
            criteria.Fields = @"  lobby.SignCity, lo.ProductOrderId as OrderId,u.Name as UserName, p.CarLoanTypeName as ProductName,
                                  lo.Amount, lobby.CreateTime as LobbyTime,mr.IsRemind,mr.RemindDate,mr.RepayId,mr.PeriodOrder ,mr.RepayDate,(case when deduPro.Code is null then '0' else deduPro.Code end )Code ,deduPro.PaymentType,
								  mr.MonthRepay,lo.IsExtension";
            criteria.PageSize = pageSize;
            criteria.CurrentPage = pageNum;
            criteria.TableName = @"  (select * , Row_Number() OVER (partition by LoanOrderId 
								  ORDER BY PeriodOrder) number from  T_LoanMonthRepay where IsDeductSucess=0 ) mr 
							        INNER JOIN T_LoanProductOrder lo on mr.LoanOrderId=lo.ProductOrderId
                                    INNER JOIN T_UserInfo u ON u.UserInfoId=lo.UserId 
                                    INNER JOIN T_LobbyInfo lobby ON lo.ProductOrderId=lobby.NewOrderId
                                    INNER JOIN T_FaceTrialInfo ft ON ft.FaceTrailId=lobby.FaceTrialId
                                    INNER JOIN T_CarLoanConfig p ON p.LoanTypeId= ft.ProductTypeId
                                    LEFT JOIN (SELECT * FROM T_Dictionary where DictKey='CarLoanRemindMark') as dict ON dict.DictValue=mr.IsRemind
									left join (select * , Row_Number() OVER (partition by OrderId , repayperiod
								  ORDER BY DeductId DESC) num from T_DeductProgress  ) deduPro on mr.LoanOrderId=deduPro.OrderId and mr.PeriodOrder=deduPro.RepayPeriod";
            criteria.PrimaryKey = "lo.ProductOrderId";
            criteria.Condition += @"  and (lo.IsDelete is null or  lo.IsDelete=0)  and (case when DAY(GETDATE())<=6 then cast(convert(varchar(7),getdate(),120)+'-06' as datetime) when
									DAY(GETDATE()) between 7 and 20 then cast(convert(varchar(7),getdate(),120)+'-20' as datetime) else cast(convert(varchar(7),dateadd(mm,1,getdate()),120)
									+'-06' as datetime )end) =mr.RepayDate and number=1 and (mr.IsRemind in (1,3,0)or mr.IsRemind is null) and (num=1 or num is null)";

            return this.GetPageDataList<CarLoanBatchDeductDto>(criteria);

        }

        /// <summary>
        /// 车贷财务报表的Excle数据读取
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<CarFinancialExportExcleDto> GetCarFinancialExportExcleList(CarFinancialExportExcleRequest model)
        {
            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            string condition = @"SELECT DISTINCT p.ProductOrderId OrderId
                                ,l.DeptId DepId,
	                                  l.SignCity,f.ProductTypeId ProductId,p.SignDate,
                                l.UserName as Name,l.IDCard,s.CovenantNo as Contract 
                                ,ub.BankName DeductBankName,ub.BankCard DeductBankAccount,ub.SubBranchName DeductBranchBank,cc.CarLoanTypeName as ProductName,
                                p.Amount ,p.Term,p.DeductDate,p.Purpose,p.UserId,p.ApplyAmount
                                ,p.[ApplyTerm] 
                                ,p.[MonthAmount] 
                                ,p.[Amount] 
                                ,p.[NetAmount] 
                                ,p.[YearRate] 
                                ,p.[RepayPerMonth] 
                                ,p.[TeamManager] 
                                ,p.[CustomerManager] 
								,lp.[ActualPayDate] ActualLenderDate
                                ,p.[ContractStartDate] 
                                ,p.[ContractEndDate] 
								,f.UserId CustomerManager
								,f.[GroupManager] TeamManagerName,
								f.[GroupManagerPhone],
								f.[CustomerManager] CustomerManagerName,
								f.[GroupNumber] TeamManagerGroup
                                FROM T_LoanProductOrder p 
                                inner join T_LobbyInfo l on p.ProductOrderId=l.NewOrderId 
                                inner join T_SignedInfo s on s.LobbyId=l.LobbyId 
                                inner join T_FaceTrialInfo f on l.FaceTrialId=f.FaceTrailId 
                                inner join T_CarLoanConfig cc on cc.LoanTypeId=f.ProductTypeId 
                                 inner join T_UserInfo u on u.UserInfoId=p.UserId 
								 inner join T_UserBankInfo ub on s.UserBankInfoId=ub.UserBankId
								 LEFT JOIN [T_PayProgress] lp ON p.ProductOrderId=lp.[OrderId]
                                where 1=1 and  p.IsDelete is null or  p.IsDelete=0";
            if (model.CityName.HasValue && model.CityName != 0)
            {
                condition += " and l.DeptId=" + model.CityName;
            }
            if (model.ProductName.HasValue && model.ProductName != 0)
            {
                condition += " and f.ProductTypeId=" + model.ProductName;
            }
            if (model.ContractDataBegin.HasValue)
            {
                condition += " and p.ContractStartDate >='" + model.ContractDataBegin.Value.ToShortDateString() + "'";
            }
            if (model.ContractDataEnd.HasValue)
            {
                condition += " and p.ContractStartDate<='" + model.ContractDataEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
            }
            //if (model.TeamName.HasValue && model.TeamName != 0)
            //{
            //    condition += " and fac.GroupNumber='" + model.TeamName;
            //}
            if (model.LoansDataBegin.HasValue)
            {
                condition += " and lp.[ActualPayDate]>='" + model.LoansDataBegin.Value.ToShortDateString() + "'";
            }
            if (model.LoansDataEnd.HasValue)
            {
                condition += " and lp.[ActualPayDate]<='" + model.LoansDataEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            return unitOfWorkContex.Context.Database.SqlQuery<CarFinancialExportExcleDto>(condition).ToList();

        }
        /// <summary>
        /// 获取待划款的订单
        /// </summary>
        /// <returns></returns>
        public List<CarLoanBatchDeductDto> GetCarLoanBatchDeductList()
        {
            string condition = @" select lobby.SignCity, lo.ProductOrderId as OrderId,u.Name as UserName, p.CarLoanTypeName as ProductName,
                                  lo.Amount, lobby.CreateTime as LobbyTime,mr.IsRemind,mr.RemindDate,mr.RepayId,mr.PeriodOrder ,mr.RepayDate,(case when deduPro.Code is null then '0' else deduPro.Code end )Code ,deduPro.PaymentType,
								  mr.MonthRepay,lo.IsExtension from (select * , Row_Number() OVER (partition by LoanOrderId 
								  ORDER BY PeriodOrder) number from  T_LoanMonthRepay where IsDeductSucess=0 ) mr 
							        INNER JOIN T_LoanProductOrder lo on mr.LoanOrderId=lo.ProductOrderId
                                    INNER JOIN T_UserInfo u ON u.UserInfoId=lo.UserId 
                                    INNER JOIN T_LobbyInfo lobby ON lo.ProductOrderId=lobby.NewOrderId
                                    INNER JOIN T_FaceTrialInfo ft ON ft.FaceTrailId=lobby.FaceTrialId
                                    INNER JOIN T_CarLoanConfig p ON p.LoanTypeId= ft.ProductTypeId
                                    LEFT JOIN (SELECT * FROM T_Dictionary where DictKey='CarLoanRemindMark') as dict ON dict.DictValue=mr.IsRemind
									left join (select * , Row_Number() OVER (partition by OrderId , repayperiod
								  ORDER BY DeductId DESC) num from T_DeductProgress  ) deduPro on mr.LoanOrderId=deduPro.OrderId and mr.PeriodOrder=deduPro.RepayPeriod where 
								  (lo.IsDelete is null or  lo.IsDelete=0)  and (case when DAY(GETDATE())<=6 then cast(convert(varchar(7),getdate(),120)+'-06' as datetime) when
									DAY(GETDATE()) between 7 and 20 then cast(convert(varchar(7),getdate(),120)+'-20' as datetime) else cast(convert(varchar(7),dateadd(mm,1,getdate()),120)
									+'-06' as datetime )end) =mr.RepayDate and number=1 and (mr.IsRemind in (1,3,0)or mr.IsRemind is null) and (num=1 or num is null) and  Code!='10' and IIF(Code='20' and PaymentType=1 ,2,1)=1";



            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            var list = unitOfWorkContex.Context.Database.SqlQuery<CarLoanBatchDeductDto>(condition).ToList();

            return list;
        }
        /// <summary>
        ///获取违约逾期报表
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public List<CarOverdueExcelDto> GetOverdueExcelList(OverdueSearchRequest overdueSearchRequest)
        {
            string mr = "0";
            if (overdueSearchRequest.Status == 1)
            {
                mr = @"(select * from  T_LoanMonthRepay where IsDeductSucess=1 and ( cast(convert(varchar(10),RepayDate,120) as datetime) +1)<ActualDeductDate" + (overdueSearchRequest.RepayDate == null ? " " : (" and cast(convert(varchar(10),RepayDate,120) as datetime)='" + overdueSearchRequest.RepayDate.Value.ToShortDateString() + "'"));
                mr += @") mr";
            }
            else if (overdueSearchRequest.Status == 2)
            {
                mr = @"(select * from  T_LoanMonthRepay where IsDeductSucess=0 and ( cast(convert(varchar(10),RepayDate,120) as datetime) +1)<ActualDeductDate and DeductOverduePenalty !=0" + (overdueSearchRequest.RepayDate == null ? " " : (" and cast(convert(varchar(10),RepayDate,120) as datetime)='" + overdueSearchRequest.RepayDate.Value.ToShortDateString() + "'"));
                mr += @") mr";
            }
            else if (overdueSearchRequest.Status == 0)
            {
                mr = @"(select * from  T_LoanMonthRepay where IsDeductSucess=0 and ( cast(convert(varchar(10),RepayDate,120) as datetime) +1)<GetDate() and DeductOverduePenalty =0" + (overdueSearchRequest.RepayDate == null ? " " : (" and cast(convert(varchar(10),RepayDate,120) as datetime)='" + overdueSearchRequest.RepayDate.Value.ToShortDateString() + "'"));
                mr += @") mr";
            }
            string condition = @"select  mr.OverduePenalty,DATEDIFF(DAY,mr.RepayDate,GETDATE()) as OverDueDays,mr.DailyPenalty,  mr.RepayDate ,GETDATE() as Date,mr.ActualDeductAmount, mr.ActualDeductDate, l.SignCity,s.CovenantNo,s.SigningDate,l.UserName,l.IdCard,
                                ub.BankCard,ub.BankName,ub.SubBranchName,p.Amount,cc.CarLoanTypeName,cc.MonthRate,cc.MonthRateTotal,cc.ComplexRateTotal,
                                mr.ToalPeriod,mr.MonthRepayPrincipal,DAY( mr.RepayDate) as RepayDay ,mrD.FirstRepaymentDate,mrD.LastRepaymentDate,
                                mr.MonthRepay,mr.ActualDeductAmount,mr.ActualDeductDate,mr.IsDeductSucess, 
                                (case when  mrC.IsDeductTerm is  null then 0 else  mrC.IsDeductTerm end) as IsDeductTerm,
                               (mr.ToalPeriod- (case when  mrC.IsDeductTerm is  null then 0 else  mrC.IsDeductTerm end)) as NotDeductTerm from T_LoanProductOrder p 
                                    inner join T_UserInfo u on u.UserInfoId = p.UserId 
									inner join (select * from T_UserBankInfo where IsDelete=0 and IsEnable=1)ub on u.UserInfoId=ub.UserId 
                                    inner join T_LobbyInfo l on p.ProductOrderId=l.NewOrderId 
									inner join T_SignedInfo s on s.LobbyId=l.LobbyId and l.SignedId=s.SignId and s.UserBankInfoId=ub.UserBankId 
                                    inner join T_FaceTrialInfo f on l.FaceTrialId=f.FaceTrailId 
                                    inner join T_CarLoanConfig cc on cc.LoanTypeId=f.ProductTypeId
                                    inner join V_CarLoanOrderOverdueInfo vcl on vcl.LoanOrderId=p.ProductOrderId
									inner join " + mr + @" on p.ProductOrderId=mr.LoanOrderId
                                    left join (select Min(RepayDate)as FirstRepaymentDate,MAX(RepayDate) as LastRepaymentDate ,LoanOrderId   from [dbo].[T_LoanMonthRepay] group by LoanOrderId ) mrD on mrD.LoanOrderId=mr.LoanOrderId
									left  join(select COUNT(*) as IsDeductTerm,LoanOrderId  from  [dbo].[T_LoanMonthRepay] where IsDeductSucess=1 group by LoanOrderId) mrC on mrC.LoanOrderId=mr.LoanOrderId
									 where  p.StatusId in (902,3010) and (p.IsDelete=0 or p.IsDelete is null)";
            if (!string.IsNullOrEmpty(overdueSearchRequest.City))
            {
                condition += string.Format(" and  l.SignCity='{0}'", overdueSearchRequest.City);
            }
            if (overdueSearchRequest.LoanTypeId != null)
            {
                condition += string.Format(" and cc.LoanTypeId={0} ", overdueSearchRequest.LoanTypeId);
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
            var list = unitOfWorkContex.Context.Database.SqlQuery<CarOverdueExcelDto>(condition).ToList();
            return list;
        }
    }
}
