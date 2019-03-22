using Autofac;
using Autofac.Integration.Wcf;
using Dscf.CarLoan.Contract;
using Dscf.CarLoan.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Dscf.CarLoan.Host
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
            builder.RegisterType<CarLoanService>().As<ICarLoanContract>().PropertiesAutowired();
            AutofacHostFactory.Container = builder.Build();
        }

        private static void SetupResolveRules(ContainerBuilder builder)
        {
            var assemblyDao = Assembly.Load("Dscf.CarLoan.Dao");
            var assemblyManager = Assembly.Load("Dscf.CarLoan.Manager");


            builder.RegisterAssemblyTypes(assemblyDao).Where(type => (type.Namespace.Equals("Dscf.CarLoan.Dao.Implement")
              || type.Namespace.Equals("Dscf.CarLoan.Dao.Context"))
              && !type.IsAbstract).AsSelf()
              .AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assemblyManager).Where(type => !type.IsAbstract && type.Namespace.Equals("Dscf.CarLoan.Manager.Implement"))
              .AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

        }
    }
}