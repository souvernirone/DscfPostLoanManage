using Autofac;
using Autofac.Integration.Wcf;
using Dscf.CreditLoan.Contract;
using Dscf.CreditLoan.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Dscf.CreditLoan.Host
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
            builder.RegisterType<CreditLoanService>().As<ICreditLoanContract>().PropertiesAutowired();
            AutofacHostFactory.Container = builder.Build();
        }

        private static void SetupResolveRules(ContainerBuilder builder)
        {
            var assemblyDao = Assembly.Load("Dscf.CreditLoan.Dao");
            var assemblyManager = Assembly.Load("Dscf.CreditLoan.Manager");


            builder.RegisterAssemblyTypes(assemblyDao).Where(type => (type.Namespace.Equals("Dscf.CreditLoan.Dao.Implement")
              || type.Namespace.Equals("Dscf.CreditLoan.Dao.Context"))
              && !type.IsAbstract).AsSelf()
              .AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assemblyManager).Where(type => !type.IsAbstract && type.Namespace.Equals("Dscf.CreditLoan.Manager.Implement"))
              .AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

        }
    }
}