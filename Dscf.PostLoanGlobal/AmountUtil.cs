using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoanGlobal
{
    public class AmountUtil
    {
        #region 月利率
        /// <summary>
        /// 月利率
        /// </summary>
        public static decimal MonthlyRate
        {
            get { return 0.01M; }
        }
        #endregion

        #region decimal?的类型转换
        private static decimal DecimalParse(decimal? DecimalVal)
        {
            if (DecimalVal.HasValue)
            {
                return Math.Round(DecimalVal.Value, 2);
            }
            else
            {
                return 0;
            }
        }

        #endregion

        #region int?的类型转换
        private static int IntParse(int? IntVal)
        {
            if (IntVal.HasValue)
            {
                return IntVal.Value;
            }
            else
            {
                return 0;
            }
        }

        #endregion

        #region 获取服务费率
        /// <summary>
        /// 获取服务费率--IF(借款类型="押车6期",0.48%,IF(OR(借款类型="GPS6期",借款类型="GPS12期"),0.58%,IF(借款类型="GPS30",1.98%,IF(借款类型="GPS60",3.78%,IF(借款类型="GPS90",5.58%,IF(借款类型="押车30",1.5%,IF(借款类型="押车60",3%,4.5%)))))))
        /// </summary>
        /// <returns></returns>
        public static decimal GetServiceRate(string ProductName)
        {
            decimal ServiceRate = 0;
            switch (ProductName)
            {
                case "押车6期":
                    ServiceRate = decimal.Parse("0.48") * decimal.Parse("0.01");
                    break;
                case "GPS6期":
                    ServiceRate = decimal.Parse("0.58") * decimal.Parse("0.01");
                    break;
                case "GPS12期":
                    ServiceRate = decimal.Parse("0.58") * decimal.Parse("0.01");
                    break;
                case "GPS30":
                    ServiceRate = decimal.Parse("1.98") * decimal.Parse("0.01");
                    break;
                case "GPS60":
                    ServiceRate = decimal.Parse("3.78") * decimal.Parse("0.01");
                    break;
                case "GPS90":
                    ServiceRate = decimal.Parse("5.58") * decimal.Parse("0.01");
                    break;
                case "押车30":
                    ServiceRate = decimal.Parse("1.5") * decimal.Parse("0.01");
                    break;
                case "押车60":
                    ServiceRate = decimal.Parse("3") * decimal.Parse("0.01");
                    break;
                default:
                    ServiceRate = decimal.Parse("4.5") * decimal.Parse("0.01");
                    break;
            }

            return Math.Round(ServiceRate, 4);
        }
        #endregion

        #region 获取月利

        /// <summary>
        /// 获取月利
        /// </summary>
        /// <param name="Amount">借款金额</param>
        /// <param name="MonthlyRate">月利率</param>
        /// <returns></returns>
        public static decimal GetMonthly(decimal? Amount, decimal? MonthlyRate)
        {
            var Monthly = DecimalParse(Amount) * DecimalParse(MonthlyRate);
            return Math.Round(Monthly, 2);
        }
        #endregion

        #region 获取总服务费
        /// <summary>
        /// 获取总服务费--IF(FIND("期",合同类型),合同金额*服务费率*期数,合同金额*服务费率)
        /// </summary>
        /// <param name="ProductName">合同类型</param>
        /// <param name="Amount">合同金额</param>
        /// <param name="ServiceRate">服务费率</param>
        /// <param name="Term">期数</param>
        /// <returns></returns>
        public static decimal GetTotalServiceCharge(string ProductName, decimal? Amount, decimal? ServiceRate, int? Term)
        {
            decimal TotalServiceCharge = ProductName.Contains("期") ? DecimalParse(Amount) * DecimalParse(ServiceRate) * IntParse(Term) : DecimalParse(Amount) * DecimalParse(ServiceRate);
            return Math.Round(TotalServiceCharge, 2);
        }
        #endregion

        #region 获取咨询费

        /// <summary>
        /// 获取咨询费--【总服务费】*0.4
        /// </summary>
        /// <param name="TotalServiceCharge"></param>
        /// <returns></returns>
        public static decimal GetConsultationFee(decimal? TotalServiceCharge)
        {
            var ConsultationFee = DecimalParse(TotalServiceCharge) * decimal.Parse("0.4");
            return Math.Round(ConsultationFee, 2);
        }
        #endregion

        #region 获取审核费

        /// <summary>
        /// 获取审核费--【总服务费】*0.1
        /// </summary>
        /// <param name="TotalServiceCharge"></param>
        /// <returns></returns>
        public static decimal GetAuditFee(decimal? TotalServiceCharge)
        {
            var AuditFee = DecimalParse(TotalServiceCharge) * decimal.Parse("0.1");
            return Math.Round(AuditFee, 2);
        }
        #endregion

        #region 获取服务费

        /// <summary>
        /// 获取服务费--【总服务费】-【咨询费】-【审核费】
        /// </summary>
        /// <param name="TotalServiceCharge">总服务费</param>
        /// <param name="ConsultationFee">咨询费</param>
        /// <param name="AuditFee">审核费</param>
        /// <returns></returns>
        public static decimal GetServiceCharge(decimal? TotalServiceCharge, decimal? ConsultationFee, decimal? AuditFee)
        {
            var ServiceCharge = DecimalParse(TotalServiceCharge) - DecimalParse(ConsultationFee) - DecimalParse(AuditFee);
            return Math.Round(ServiceCharge, 2);
        }
        #endregion

        #region 获取代收手续费上限（待修改）
        /// <summary>
        /// 获取代收手续费上限--IF(COUNTIFS(G:G,G2,E:E,"<"&E2)>0,"3%",IF(LEFT(借款类型,3)="GPS","3%","5%"))*合同金额
        /// </summary>
        /// <returns></returns>
        public static decimal GetCollectionFeeLimit()
        {
            return 0;
        }
        #endregion

        #region 获取前期费用
        /// <summary>
        /// 获取前期费用--【总服务费】+实收手续费+【前期费用】 +【GPS安装费】+【停车费】+【保证金】
        /// </summary>
        /// <param name="TotalServiceCharge">总服务费</param>
        /// <param name="PaidFee">实收手续费</param>
        /// <param name="GPSInstallationFee">GPS安装费</param>
        /// <param name="ParkingFee">停车费</param>
        /// <param name="Margin">保证金</param>
        /// <returns></returns>
        public static decimal GetInitialExpenses(decimal? TotalServiceCharge, decimal? PaidFee, decimal? GPSInstallationFee, decimal? ParkingFee, decimal? Margin)
        {
            var InitialExpenses = DecimalParse(TotalServiceCharge) + DecimalParse(PaidFee) + DecimalParse(GPSInstallationFee) + DecimalParse(ParkingFee) + DecimalParse(Margin);
            return Math.Round(InitialExpenses, 2);
        }
        #endregion

        #region 获取GPS安装费
        /// <summary>
        /// 获取GPS安装费--IF(LEFT(借款类型,3)="GPS",IF(合同金额>200000,"1500","1000"),"0")
        /// </summary>
        /// <param name="ProductName">借款类型</param>
        /// <param name="Amount">合同金额</param>
        /// <returns></returns>
        public static decimal GetGPSInstallationFee(string ProductName, decimal? Amount)
        {
            decimal GPSInstallationFee = ProductName.Contains("GPS") ? (DecimalParse(Amount) > 200000 ? 1500 : 1000) : 0;
            return Math.Round(GPSInstallationFee, 2);
        }
        #endregion

        #region 获取停车费
        /// <summary>
        /// 获取停车费--IF(LEFT(借款类型,3)="GPS","0","500")
        /// </summary>
        /// <param name="ProductName">借款类型</param>
        /// <returns></returns>
        public static decimal GetParkingFee(string ProductName)
        {
            decimal ParkingFee = ProductName.Contains("GPS") ? 0 : 500;
            return Math.Round(ParkingFee, 2);
        }
        #endregion

        #region 获取流量费
        /// <summary>
        /// 获取流量费--IF(LEFT(借款类型,3)="GPS","100","")
        /// </summary>
        /// <param name="ProductName">借款类型</param>
        /// <returns></returns>
        public static decimal GetTrafficCharges(string ProductName)
        {
            decimal TrafficCharges = ProductName.Contains("GPS") ? 100 : 0;
            return Math.Round(TrafficCharges, 2);
        }
        #endregion

        #region 获取保证金
        public static decimal GetMargin(string ProductName, decimal? Amount)
        {
            decimal Margin = 0;

            if (ProductName == "GPS90")
            {
                Margin = DecimalParse(Amount) * decimal.Parse("0.02");
            }
            else
            {
                if (ProductName.Contains("GPS"))
                {
                    Margin = DecimalParse(Amount) * decimal.Parse("0.03");
                }
                else
                {
                    Margin = 0;
                }
            }
            return Math.Round(Margin, 2);
        }

        #endregion

        #region 获取月还本金

        /// <summary>
        /// 获取月还本金--ROUND(IFERROR(IF(FIND("期",借款类型),合同金额/期数,0),0),2)
        /// </summary>
        /// <param name="Amount">合同金额</param>
        /// <param name="ProductName">借款类型</param>
        /// <param name="Term">期数</param>
        /// <returns></returns>
        public static decimal GetMonthAlsoPrincipal(decimal? Amount, string ProductName, int? Term)
        {
            return ProductName.Contains("期") ? Math.Round(DecimalParse(Amount) / IntParse(Term), 2) : 0;
        }
        #endregion

        #region 获取等额月还

        /// <summary>
        /// 获取等额月还--IF(FIND("期",借款类型),合同金额/期数+月利,0)
        /// </summary>
        /// <param name="Amount">合同金额</param>
        /// <param name="ProductName">借款类型</param>
        /// <param name="Term">期数</param>
        /// <param name="Monthly">月利</param>
        /// <returns></returns>
        public static decimal GetEqualMonthlyReturn(decimal? Amount, string ProductName, int? Term, decimal? Monthly)
        {
            return ProductName.Contains("期") ? Math.Round(DecimalParse(Amount) / (IntParse(Term) == 0 ? 1 : IntParse(Term)), 2) + Math.Round(DecimalParse(Monthly), 2) : 0;
        }
        #endregion

        #region 获取实际月还
        /// <summary>
        /// 获取实际月还--ROUND(IF(LEFT(借款类型,3)="GPS",【月还本金】+【月利】+【流量费】,【月利】+【月还本金】+【停车费】),2)
        /// </summary>
        /// <param name="MonthAlsoPrincipal">月还本金</param>
        /// <param name="Monthly">月利</param>
        /// <param name="TrafficCharges">流量费</param>
        /// <param name="ParkingFee">停车费</param>
        /// <param name="ProductName">借款类型</param>
        /// <returns></returns>
        public static decimal GetTheSameMonth(decimal? MonthAlsoPrincipal, decimal? Monthly, decimal? TrafficCharges, decimal? ParkingFee, string ProductName)
        {
            decimal TheSameMonth = 0;
            if (ProductName.Contains("GPS"))
            {
                TheSameMonth = DecimalParse(MonthAlsoPrincipal) + DecimalParse(Monthly) + DecimalParse(TrafficCharges);
            }
            else
            {
                TheSameMonth = DecimalParse(MonthAlsoPrincipal) + DecimalParse(Monthly) + DecimalParse(ParkingFee);
            }
            return Math.Round(TheSameMonth, 2);
        }
        #endregion

        #region 累计应还款总额
        /// <summary>
        ///  累计应还款总额--ROUND(IFERROR(IF(FIND("期",借款类型),【实际月还】*期数,0),0),2)
        /// </summary>
        /// <param name="ProductName">借款类型</param>
        /// <param name="TheSameMonth">实际月还</param>
        /// <param name="Term">期数</param>
        /// <returns></returns>
        public static decimal GetTotalShouldRepaid(string ProductName, decimal? TheSameMonth, int? Term)
        {
            decimal TotalShouldRepaid = ProductName.Contains("期") ? DecimalParse(TheSameMonth) * IntParse(Term) : 0;
            return Math.Round(TotalShouldRepaid, 2);
        }

        #endregion

        #region 获取折标业绩
        /// <summary>
        /// 获取折标业绩-- IF(OR(借款类型="押车6期",借款类型="GPS6期"),50%*合同金额,IF(OR(借款类型="押车30",借款类型="GPS30"),10%*合同金额,IF(OR(借款类型="押车60",借款类型="GPS60"),20%*合同金额,IF(OR(借款类型="押车90",借款类型="GPS90"),30%*合同金额,100%*合同金额)))
        /// </summary>
        /// <param name="ProductName">产品名称</param>
        /// <param name="Amount">合同金额</param>
        /// <returns></returns>
        public static decimal GetDiscountPerformance(string ProductName, decimal? Amount)
        {
            decimal DiscountPerformance = 0;
            switch (ProductName)
            {
                case "押车6期":
                    DiscountPerformance = DecimalParse(Amount) * decimal.Parse("0.5");
                    break;
                case "GPS6期":
                    DiscountPerformance = DecimalParse(Amount) * decimal.Parse("0.5");
                    break;
                case "押车30":
                    DiscountPerformance = DecimalParse(Amount) * decimal.Parse("0.1");
                    break;
                case "GPS30":
                    DiscountPerformance = DecimalParse(Amount) * decimal.Parse("0.1");
                    break;
                case "押车60":
                    DiscountPerformance = DecimalParse(Amount) * decimal.Parse("0.2");
                    break;
                case "GPS60":
                    DiscountPerformance = DecimalParse(Amount) * decimal.Parse("0.2");
                    break;
                case "押车90":
                    DiscountPerformance = DecimalParse(Amount) * decimal.Parse("0.3");
                    break;
                case "GPS90":
                    DiscountPerformance = DecimalParse(Amount) * decimal.Parse("0.3");
                    break;
                default:
                    DiscountPerformance = DecimalParse(Amount) * decimal.Parse("1");
                    break;
            }
            return Math.Round(DiscountPerformance, 2);
        }
        #endregion

        #region 是否已到期
        /// <summary>
        /// 是否已到期--IF(【末次还款日期】<=TODAY(),"到期","未到期")
        /// </summary>
        /// <param name="LastRepaymentDate">末次还款日期</param>
        /// <returns></returns>
        public static bool GetIsExpire(DateTime? LastRepaymentDate)
        {
            return LastRepaymentDate < DateTime.Now ? true : false;
        }
        #endregion

        #region 获取应还款期数
        /// <summary>
        /// 获取应还款期数--DATEDIF(【首次还款日期】,TODAY(),"m")+1
        /// </summary>
        /// <param name="FirstRepaymentDate">首次还款日期</param>
        /// <returns></returns>
        public static int GetRepaymentPeriod(DateTime? FirstRepaymentDate)
        {
            DateTime Today = DateTime.Now;
            int RepaymentPeriod = 0;
            if (FirstRepaymentDate.HasValue)
            {
                RepaymentPeriod = (Today.Year - FirstRepaymentDate.Value.Year) * 12 + (Today.Month - FirstRepaymentDate.Value.Month) + 1;
            }
            return RepaymentPeriod;
        }
        #endregion

        #region 获取剩余期数
        /// <summary>
        /// 获取剩余期数
        /// </summary>
        /// <param name="Term">期数</param>
        /// <param name="CumulativeReturnPeriod">已还期数</param>
        /// <returns></returns>
        public static int? GetRemainingPeriod(int? Term, int? CumulativeReturnPeriod)
        { 
            if(!Term.HasValue)return 0;
            if(!CumulativeReturnPeriod.HasValue)return IntParse(Term);
            return IntParse(Term) - IntParse(CumulativeReturnPeriod);
        }
        #endregion

        #region 获取剩余应还本金
        /// <summary>
        /// 获取剩余应还本金--合同金额/期数*【剩余期数】
        /// </summary>
        /// <param name="Amount">合同金额</param>
        /// <param name="Term">期数</param>
        /// <param name="RemainingPeriod">剩余期数</param>
        /// <returns></returns>
        public static decimal GetSurplusPrincipal(decimal? Amount, int? Term, int? RemainingPeriod)
        {
            return Math.Round(DecimalParse(Amount) / (IntParse(Term) == 0 ? 1 : IntParse(Term)), 2) * IntParse(RemainingPeriod);
        }
        #endregion

        #region 获取提前还款违约金
        /// <summary>
        /// 获取提前还款违约金
        /// </summary>
        /// <param name="FinancialExportExcleDto">财务报表DTO</param>
        /// <returns></returns>
        public static decimal GetPrepaymentPenalty(int? RepaymentPeriod, int? Term, string ProductName, decimal? Amount)
        {
            decimal PrepaymentPenalty = 0;
            RepaymentPeriod = IntParse(RepaymentPeriod);
            if (RepaymentPeriod < IntParse(Term))
            {
                if (ProductName.Contains("期"))
                {
                    if (RepaymentPeriod <= 3)
                    {
                        PrepaymentPenalty = DecimalParse(Amount) * decimal.Parse("0.05");
                    }
                    else
                    {
                        if (RepaymentPeriod > 3 && RepaymentPeriod <= IntParse(Term) / 2)
                        {
                            PrepaymentPenalty = DecimalParse(Amount) * decimal.Parse("0.03");
                        }
                        else
                        {
                            PrepaymentPenalty = DecimalParse(Amount) * decimal.Parse("0.02");
                        }
                    }
                }
                else
                {
                    if (RepaymentPeriod <= 3)
                    {
                        PrepaymentPenalty = DecimalParse(Amount) * decimal.Parse("0.05");
                    }
                    else
                    {
                        if (RepaymentPeriod > 3 && RepaymentPeriod <= IntParse(Term) / 2)
                        {
                            PrepaymentPenalty = DecimalParse(Amount) * decimal.Parse("0.03");
                        }
                        else
                        {
                            PrepaymentPenalty = DecimalParse(Amount) * decimal.Parse("0.02");
                        }
                    }
                }
            }
            return Math.Round(PrepaymentPenalty, 2);
        }
        #endregion

        #region 获取提前还款金额
        /// <summary>
        /// 获取提前还款金额
        /// </summary>
        /// <param name="FinancialExportExcleDto">财务报表DTO</param>
        /// <returns></returns>
        public static decimal GetPrepaymentAmount(int? RemainingPeriod, string ProductName, decimal? Monthly, decimal? SurplusPrincipal, decimal? Margin, decimal? TrafficCharges, decimal? Amount, decimal? PrepaymentPenalty)
        {
            RemainingPeriod = IntParse(RemainingPeriod);
            decimal PrepaymentAmount = 0;
            if (RemainingPeriod == 0)
            {
                PrepaymentAmount = 0;
            }
            else
            {
                if (RemainingPeriod == 1 || RemainingPeriod == 0)
                {
                    if (ProductName == "押车6期")
                    {
                        PrepaymentAmount = DecimalParse(Monthly) + DecimalParse(SurplusPrincipal);
                    }
                    else
                    {
                        if (ProductName == "GPS6期" || ProductName == "GPS12期")
                        {
                            PrepaymentAmount = DecimalParse(SurplusPrincipal) + DecimalParse(Monthly) + DecimalParse(TrafficCharges) - DecimalParse(Margin);
                        }
                        else
                        {
                            if (ProductName == "GPS30" || ProductName == "GPS60" || ProductName == "GPS90")
                            {
                                PrepaymentAmount = DecimalParse(Amount) + DecimalParse(Monthly) + DecimalParse(TrafficCharges) - DecimalParse(Margin);
                            }
                            else
                            {
                                PrepaymentAmount = DecimalParse(Amount) + DecimalParse(Monthly);
                            }
                        }
                    }
                }
                else
                {
                    if (ProductName == "押车6期")
                    {
                        PrepaymentAmount = DecimalParse(Monthly) + DecimalParse(SurplusPrincipal) + DecimalParse(PrepaymentPenalty);
                    }
                    else
                    {
                        if (ProductName == "GPS6期" || ProductName == "GPS12期")
                        {
                            PrepaymentAmount = DecimalParse(SurplusPrincipal) + DecimalParse(PrepaymentPenalty) + DecimalParse(Monthly) + DecimalParse(TrafficCharges) - DecimalParse(Margin);
                        }
                        else
                        {
                            if (ProductName == "GPS30" || ProductName == "GPS60" || ProductName == "GPS90")
                            {
                                PrepaymentAmount = DecimalParse(Amount) + DecimalParse(Monthly) + DecimalParse(TrafficCharges) - DecimalParse(Margin);
                            }
                            else
                            {
                                PrepaymentAmount = DecimalParse(Amount) + DecimalParse(Monthly);
                            }
                        }
                    }
                }
            }
            return Math.Round(PrepaymentAmount, 2);
        }

        #endregion

        #region 获取首次还款日期

        /// <summary>
        /// 获取首次还款日期
        /// </summary>
        /// <param name="Term">期数</param>
        /// <param name="ActualLenderDate">实际放款日期</param>
        /// <returns></returns>
        public static DateTime? GetFirstRepaymentDate(int? Term, DateTime? ActualLenderDate)
        {
            if (!ActualLenderDate.HasValue) return null;
            int ActualDay = ActualLenderDate.Value.Day;
            DateTime? FirstRepaymentDate = null;
            var RepaymentDateAfter = ActualLenderDate.Value.AddMonths(1);//实际放款月的下一个月
            var RepaymentDateBefore = DateTime.Parse(ActualLenderDate.Value.ToString("yyyy-MM-1")).AddDays(-1).AddMonths(1);//实际放款月的最后一天
            if (IntParse(Term) == 12 || IntParse(Term) == 6)
            {
                if (ActualDay >= 6 && ActualDay <= 19)
                {
                    FirstRepaymentDate = DateTime.Parse(RepaymentDateAfter.ToString("yyyy-MM-6"));
                }
                else
                {
                    if (ActualDay > 19 && ActualDay <= 31)
                    {
                        FirstRepaymentDate = DateTime.Parse(RepaymentDateAfter.ToString("yyyy-MM-20"));
                    }
                    else
                    {
                        FirstRepaymentDate = DateTime.Parse(ActualLenderDate.Value.ToString("yyyy-MM-20"));
                    }
                }
            }
            else
            {
                if (RepaymentDateBefore.Day < ActualDay)//实际放款月的最后一天<实际放款日
                {
                    FirstRepaymentDate = RepaymentDateBefore;
                }
                else
                {
                    FirstRepaymentDate = RepaymentDateAfter;
                }
            }
            return FirstRepaymentDate;
        }
   
        #endregion

        #region 获取末次还款日期

        /// <summary>
        /// 获取末次还款日期
        /// </summary>
        /// <param name="Term">期数</param>
        /// <param name="FirstRepaymentDate">首次还款日期</param>
        /// <returns></returns>
        public static DateTime? GetLastRepaymentDate(int? Term, DateTime? FirstRepaymentDate)
        {
            if (!FirstRepaymentDate.HasValue)return null;
            var LastRepaymentDate = FirstRepaymentDate.Value.AddMonths(IntParse(Term));
            return LastRepaymentDate;
        }
        #endregion
    }
}
