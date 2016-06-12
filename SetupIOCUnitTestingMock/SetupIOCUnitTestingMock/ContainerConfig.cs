using Autofac;
using Autofac.Integration.Mvc;
using SetupIOCUnitTestingMock.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetupIOCUnitTestingMock
{
    public class ContainerConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //   builder.RegisterType<HomeController>().InstancePerRequest();
            builder.RegisterType<Adviser>().As<IAdviser>().SingleInstance();

            builder.RegisterFilterProvider();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}