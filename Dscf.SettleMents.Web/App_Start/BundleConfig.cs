using System.Web;
using System.Web.Optimization;

namespace Dscf.SettleMents.Web
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
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
            //模板
            bundles.Add(new ScriptBundle("~/bundles/templete").Include("~/Scripts/jquery.tmpl.min.js"));

            //表单验证
            bundles.Add(new ScriptBundle("~/bundles/validator").Include("~/Scripts/jquery.validate.js"));

            //unobtrusive
            bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include("~/Scripts/jquery.validate.unobtrusive.js", "~/Scripts/jquery.unobtrusive-ajax.js"));

            //WebUploader文件上传Script文件
            bundles.Add(new ScriptBundle("~/bundles/uploader").Include("~/Scripts/WebUploader/webuploader.js"));

            //WebUploader文件上传Script文件
            bundles.Add(new StyleBundle("~/content/uploader").Include("~/Content/webuploader.css"));

            //综合查询信息Script文件
            bundles.Add(new ScriptBundle("~/bundles/settleMentJs").Include("~/Scripts/settleMentJs/loanInfoList.js"));

            //综合查询Script文件
            bundles.Add(new ScriptBundle("~/bundles/creditOrCarLoanInfoDetaiJs").Include("~/Scripts/settleMentJs/creditOrCarLoanInfoDetails.js"));
            bundles.Add(new ScriptBundle("~/bundles/creditBatchDeductClaimsJs").Include("~/Scripts/settleMentJs/creditBatchDeductClaimsJS.js"));
            bundles.Add(new ScriptBundle("~/bundles/settleMentListJs").Include("~/Scripts/settleMentJs/settleMentList.js"));
            //报表导出的Script文件
            bundles.Add(new ScriptBundle("~/bundles/exportExcleJs").Include("~/Scripts/excleInfo/exportExcle.js"));
        }
    }
}