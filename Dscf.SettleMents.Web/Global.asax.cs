using Dscf.SettleMents.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Dscf.SettleMents.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            Dscf.SettleMents.Web.RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //初始化AutoMapper
            AutoMapperStrapper.RegisterMaps();

            //初始化Log4Net
            log4net.Config.XmlConfigurator.Configure();

            //初始化Autofac
            AutoFacBootStrapper.AutoFacInit();

        }
    }
}