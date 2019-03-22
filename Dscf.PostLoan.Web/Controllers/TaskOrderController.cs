using Dscf.PostLoanGlobal;
using Dscf.PostLoan.AuthCenterBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dscf.PostLoan.Web.Controllers
{
    public class TaskOrderController : BaseController
    {
        public OperaterInfoBLL OperaterInfoBLL { get; set; }

        public OptDeptBLL OptDeptBLL { get; set; }

        public DictionaryBLL DictionaryBLL { get; set; }


        public ActionResult Process()
        {
            IList<int> roleIdList = new List<int>() { RoleUtil.CreditLoanCollectorRole, RoleUtil.CarLoanCollectorRole };

            var CollectorArray = OperaterInfoBLL.QueryCollectorListByRole(roleIdList);

            //信贷催收操作员
            ViewBag.CreditLoanCollector = CollectorArray.Where(opt => opt.RoleIdList.Contains(RoleUtil.CreditLoanCollectorRole));

            //车贷催收操作员
            ViewBag.CarLoanCollector = CollectorArray.Where(opt => opt.RoleIdList.Contains(RoleUtil.CarLoanCollectorRole));

            ViewBag.CollectionTypeList = DictionaryBLL.GetDictListByKey(DictUtil.CollectionTypeKey);

            return View();
        }

        public JsonResult RegistCity(int id, IList<int> cityIdList,int sourceType)
        {
            if (cityIdList == null)
            {
                cityIdList = new List<int>();
            }
            OptDeptBLL.UpdateCollectorSupportCityList(id, cityIdList.ToArray(), sourceType);
            var result = new ResultMessage(true, "更新催收支持城市信息成功!");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult QuerySupportCity(string role, int typeId)
        {
            int roleId = string.Equals(role, "CarLoan") ? RoleUtil.CarLoanCollectorRole : RoleUtil.CreditLoanCollectorRole;
            var data=OperaterInfoBLL.GetCollectorSupportCityList(roleId, typeId);
            ResultMessage result = new ResultMessage(true, "查询已支持城市信息成功!", data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult UpdateOptCollectionType(int optId ,int type)
        {
            OperaterInfoBLL.UpdateOptCollectionType(optId, type);
            var result = new ResultMessage(true, "更新催收类型信息成功!");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}