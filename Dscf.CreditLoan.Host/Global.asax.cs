using HibernatingRhinos.Profiler.Appender.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Dscf.CreditLoan.Host
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            EntityFrameworkProfiler.Initialize();

            //初始化Log4Net
            log4net.Config.XmlConfigurator.Configure();
            //初始化Autofac
            AutoFacBootStrapper.AutoFacInit();

            //初始化AutoMapper
            AutoMapperStrapper.RegisterMaps();
        }

    }
}