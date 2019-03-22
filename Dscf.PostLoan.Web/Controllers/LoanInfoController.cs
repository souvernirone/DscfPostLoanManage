using Dscf.PostLoan.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dscf.PostLoanGlobal;
using Dscf.PostLoan.CarLoanBLL;
using Dscf.PostLoan.CreditLoanBLL;
using Dscf.PostLoan.Web.Helper;
using Dscf.PostLoan.AuthCenterBLL;
using System;
namespace Dscf.PostLoan.Web.Controllers
{
    public class LoanInfoController : BaseController
    {

        public CarLoanOrderProductBLL CarLoanOrderProductBLL { get; set; }
        public CarLoanMonthRepayBLL CarLoanMonthRepayBLL { get; set; }
        public CreditLoanInfoBLL CreditLoanInfoBLL { get; set; }
        public CreditLoan_MonthRepayBLL CreditLoan_MonthRepayBLL { get; set; }
        public LoginInfoHelper LoginInfoHelper { get; set; }
        public OperaterInfoBLL OperaterInfoBLL { get; set; }
        //
        // GET: /LoanInfo/
        public ActionResult Index()
        {
            //订单类型
            return View();
        }
        public ActionResult LoanInfoList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            int[] roles = OperaterInfoBLL.GetRoleIdsById(LoginInfoHelper.Operater().Id);
            if (roles.Contains(RoleUtil.CollectionSupervisor))
            {
                list.Add(new SelectListItem() { Text = "信贷订单", Value = "1", Selected = true });
                list.Add(new SelectListItem() { Text = "车贷订单", Value = "2" });
            }
            else if (roles.Contains(RoleUtil.CarLoanCollectorRole))
            {
                list.Add(new SelectListItem() { Text = "车贷订单", Value = "2" });
            }
            else if (roles.Contains(RoleUtil.CreditLoanCollectorRole))
            {
                list.Add(new SelectListItem() { Text = "信贷订单", Value = "1" });
            }
            ViewData["custromType"] = list.AsEnumerable();
            return View();

        }
        /// <summary>
        /// 查看单个贷款信息详情
        /// </summary>
        /// <param name="loaninfo"></param>
        /// <returns></returns>
        public ActionResult CreditOrCarLoanInfoDetails(string orderType, string orderid)
        {
            switch (orderType)
            {
                case "1":
                    var operater = LoginInfoHelper.Operater();
                    LoanSearchViewModel loanSearchViewModel = new LoanSearchViewModel() { OrderId = orderid, OptId = operater.Id, PageSize = 10, PageNum = 1 };
                    Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.LoanInfoDto loaninfo = CreditLoanInfoBLL.GetPageLoanInfoList(loanSearchViewModel).CurrentPageItems.ToList()[0];

                    //获取月还信息
                    Loan_MonthRepayViewModel[] loanmonthrepaylist = CreditLoan_MonthRepayBLL.GetLoan_MonthRepayInfoByorderID(Int32.Parse(orderid));
                    var loanmonthtemp = loanmonthrepaylist.Count() > 0 ? loanmonthrepaylist : null;
                    ViewData["LoanMonth"] = loanmonthtemp;
                    return View("CreditLoanInfoDetails", loaninfo);
                default:
                    var carLoan = CarLoanOrderProductBLL.GetLoanProductOrderInfoByOrderId(Convert.ToInt32(orderid));
                    return View("CarLoanInfoDetail", carLoan);
            }
        }

        /// <summary>
        /// 查询车贷月还信息列表
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public JsonResult QueryCarRepayList(int orderId)
        {
            var data = CarLoanMonthRepayBLL.GetLoanMonthRepayInfoByOrderId(orderId);
            ResultMessage result = new ResultMessage(true, "查询车贷订单的月还信息成功!", data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 获取贷款信息列表
        /// </summary>
        /// <param name="loanSearchViewModel"></param>
        /// <returns></returns>
        public JsonResult GetPageLoanInfoList(LoanSearchViewModel loanSearchViewModel)
        {
            var operater = LoginInfoHelper.Operater();
            loanSearchViewModel.OptId = operater.Id;
            switch (loanSearchViewModel.OrderType)
            {
                case "1":
                    //调用信贷              
                    var datas = CreditLoanInfoBLL.GetPageLoanInfoList(loanSearchViewModel);
                    datas.CurrentPageItems.ToList().ForEach(vm => { vm.OrderType = 1; });
                    var result = new ResultMessage(true, "加载信息成功", datas.TotalItemCount, datas);
                    return Json(result, JsonRequestBehavior.AllowGet);
                default:
                    //调用车贷
                    var orderList = CarLoanOrderProductBLL.SelectLoanProductOrderList(loanSearchViewModel);
                    orderList.CurrentPageItems.ToList().ForEach(vm => { vm.OrderType = 2; });
                    var carResult = new ResultMessage(true, "加载信息成功", orderList.TotalItemCount, orderList);
                    return Json(carResult, JsonRequestBehavior.AllowGet);
            }

        }
    }
}