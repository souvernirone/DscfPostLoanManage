using Dscf.PostLoan.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dscf.PostLoan.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //错误日志异常处理过滤器
            filters.Add(new LogHandleErrorAttribute());
        }
    }
}