using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Dscf.PostLoan.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
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