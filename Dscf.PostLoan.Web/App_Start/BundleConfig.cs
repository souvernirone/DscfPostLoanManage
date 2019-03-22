using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Dscf.PostLoan.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
              "~/Scripts/jquery-1.11.2.min.js", "~/Scripts/perfect-scrollbar.min.js", "~/Scripts/base.js", "~/Scripts/jquery-extension.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepickerJs").Include("~/Scripts/datepicker.js", "~/Scripts/datepicker-zh-CN.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataPagerJs").Include("~/Scripts/jquery.tmpl.min.js", "~/Scripts/laypage.js", "~/Scripts/datapager.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataFormat").Include("~/Scripts/jquery-dateFormat.js"));

            //表单AJAX提交Script文件
            bundles.Add(new ScriptBundle("~/bundles/form").Include("~/Scripts/jquery.form.js"));

            //共用CSS
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/base.min.css", "~/Content/common.css",
                "~/Content/perfect-scrollbar.css", "~/Content/style.css"));

            //日期选择其CSS
            bundles.Add(new StyleBundle("~/Content/css/datepicker").Include("~/Content/datetimepicker.min.css"));

            //弹框Dialog脚本文件
            bundles.Add(new ScriptBundle("~/bundles/dialog").Include("~/Scripts/layer.js"));

            //任务派单Script文件
            bundles.Add(new ScriptBundle("~/bundles/process").Include("~/Scripts/TaskOrder/process.js"));

            //信贷信息Script文件
            bundles.Add(new ScriptBundle("~/bundles/loanInfoList").Include("~/Scripts/LoanInfoJs/loanInfoList.js"));

            //车贷借款信息Script文件
            bundles.Add(new ScriptBundle("~/bundles/carLoanInfoDetail").Include("~/Scripts/LoanInfoJs/carLoanInfoDetail.js"));

            //借款还款提醒Script文件
            bundles.Add(new ScriptBundle("~/bundles/_RepayRemindList").Include("~/Scripts/RepayRemind/_RepayRemindList.js"));

            //车辆借款还款提醒列表Script文件
            bundles.Add(new ScriptBundle("~/bundles/carRemindList").Include("~/Scripts/RepayRemind/carRemindList.js"));

            //模板
            bundles.Add(new ScriptBundle("~/bundles/templete").Include("~/Scripts/jquery.tmpl.min.js"));

            //表单验证
            bundles.Add(new ScriptBundle("~/bundles/validator").Include("~/Scripts/jquery.validate.js"));

            //unobtrusive
            bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include("~/Scripts/jquery.validate.unobtrusive.js", "~/Scripts/jquery.unobtrusive-ajax.js"));

            //车辆展期提醒
            bundles.Add(new ScriptBundle("~/bundles/carRemindExtensionDetail").Include("~/Scripts/RepayRemind/carRemindExtensionDetail.js"));

            //信用借款逾期客户详情Script文件
            bundles.Add(new ScriptBundle("~/bundles/creditOverdueDetail").Include("~/Scripts/OverdueCustomer/creditOverdueDetail.js"));

            //车贷逾期客户详情Script文件
            bundles.Add(new ScriptBundle("~/bundles/carOverdueDetail").Include("~/Scripts/OverdueCustomer/carOverdueDetail.js"));

            //催收信息创建Script文件
            bundles.Add(new ScriptBundle("~/bundles/collectionCreate").Include("~/Scripts/CollectionInfo/create.js"));

            //还款提醒记录Excle导出
            bundles.Add(new ScriptBundle("~/bundles/RemindExcleList").Include("~/Scripts/ExcleInfo/RemindExcleList.js"));
            //逾期报表和财务报表
            bundles.Add(new ScriptBundle("~/bundles/exportExcleJs").Include("~/Scripts/ExcleInfo/exportExcle.js"));

            //Tab新增信息Script文件
            bundles.Add(new ScriptBundle("~/bundles/extraInfoTab").Include("~/Scripts/ExtraInfo/extraInfoTab.js"));

            //催收信息查改删Script文件
            bundles.Add(new ScriptBundle("~/bundles/collectionInfo").Include("~/Scripts/OverdueCustomer/collectionInfo.js"));

            //WebUploader文件上传Script文件
            bundles.Add(new ScriptBundle("~/bundles/uploader").Include("~/Scripts/WebUploader/webuploader.js"));

            //WebUploader文件上传Script文件
            bundles.Add(new StyleBundle("~/content/uploader").Include("~/Content/webuploader.css"));


        }
    }
}