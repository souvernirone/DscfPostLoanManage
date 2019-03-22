using Autofac;
using Autofac.Integration.Wcf;
using Dscf.LoanAfter.Contract;
using Dscf.LoanAfter.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Dscf.LoanAfter.Host
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
            builder.RegisterType<LoanAfterService>().As<ILoanAfterContract>().PropertiesAutowired();
            AutofacHostFactory.Container = builder.Build();
        }

        private static void SetupResolveRules(ContainerBuilder builder)
        {
            var assemblyDao = Assembly.Load("Dscf.LoanAfter.Dao");
            var assemblyManager = Assembly.Load("Dscf.LoanAfter.Manager");


            builder.RegisterAssemblyTypes(assemblyDao).Where(type => (type.Namespace.Equals("Dscf.LoanAfter.Dao.Implement")
              || type.Namespace.Equals("Dscf.LoanAfter.Dao.Context"))
              && !type.IsAbstract).AsSelf()
              .AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assemblyManager).Where(type => !type.IsAbstract && type.Namespace.Equals("Dscf.LoanAfter.Manager.Implement"))
              .AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

        }
    }
}