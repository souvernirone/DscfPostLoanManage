using Autofac;
using Autofac.Integration.Wcf;
using Dscf.AuthCenter.Contract;
using Dscf.AuthCenter.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Dscf.AuthCenter.Host
{
    /// <summary>
    /// 初始化Autofac
    /// </summary>
    public static class AutoFacBootStrapper
    {
        public static void AutoFacInit()
        {
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            builder.RegisterType<AuthCenterService>().As<IAuthCenterContract>().PropertiesAutowired();
            AutofacHostFactory.Container = builder.Build();
        }

        private static void SetupResolveRules(ContainerBuilder builder)
        {
            var assemblyDao = Assembly.Load("Dscf.AuthCenter.Dao");
            var assemblyManager = Assembly.Load("Dscf.AuthCenter.Manager");


            builder.RegisterAssemblyTypes(assemblyDao).Where(type => (type.Namespace.Equals("Dscf.AuthCenter.Dao.Implement")
              || type.Namespace.Equals("Dscf.AuthCenter.Dao.Context"))
              && !type.IsAbstract).AsSelf()
              .AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assemblyManager).Where(type => !type.IsAbstract && type.Namespace.Equals("Dscf.AuthCenter.Manager.Implement"))
              .AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

        }
    }
}