using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Dscf.PostLoan.Web
{
    public static class AutoFacBootStrapper
    {
        public static void AutoFacInit()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.开启属性注入
            builder.RegisterControllers(typeof(AutoFacBootStrapper).Assembly).PropertiesAutowired();

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            SetupResolveRules(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void SetupResolveRules(ContainerBuilder builder)
        {
            //依赖注入AuthCenter业务逻辑层
            var assemblyAuthCenterBLL = Assembly.Load("Dscf.PostLoan.AuthCenterBLL");
            builder.RegisterAssemblyTypes(assemblyAuthCenterBLL).Where(type => (type.Namespace.Equals("Dscf.PostLoan.AuthCenterBLL"))
            && !type.IsAbstract).AsSelf().AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

            //依赖注入CreditLoan业务逻辑层
            var assemblyCreditLoanBLL = Assembly.Load("Dscf.PostLoan.CreditLoanBLL");
            builder.RegisterAssemblyTypes(assemblyAuthCenterBLL).Where(type => (type.Namespace.Equals("Dscf.PostLoan.AuthCenterBLL"))
            && !type.IsAbstract).AsSelf().AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assemblyCreditLoanBLL).Where(type => (type.Namespace.Equals("Dscf.PostLoan.CreditLoanBLL"))
            && !type.IsAbstract).AsSelf().AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

            //依赖注入CarLoan业务逻辑层
            var assemblyCarLoanBLL = Assembly.Load("Dscf.PostLoan.CarLoanBLL");

            builder.RegisterAssemblyTypes(assemblyCarLoanBLL).Where(type => (type.Namespace.Equals("Dscf.PostLoan.CarLoanBLL"))
            && !type.IsAbstract).AsSelf().AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

            //依赖注入LoanAfter业务逻辑层
            var assemblyLoanAfterBLL = Assembly.Load("Dscf.PostLoan.LoanAfterBLL");

            builder.RegisterAssemblyTypes(assemblyLoanAfterBLL).Where(type => (type.Namespace.Equals("Dscf.PostLoan.LoanAfterBLL"))
            && !type.IsAbstract).AsSelf().AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();
        }
    }
}