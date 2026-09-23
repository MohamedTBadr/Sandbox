using Autofac;
using Autofac.Integration.WebApi;
using Sandbox.Consumers;
using Sandbox.Models;
using Sandbox.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Sandbox.App_Start
{
    public static class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            // Register your dependencies here
            var builder = new ContainerBuilder();
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<TaskService>().As<ITaskService>().InstancePerRequest();



            builder.RegisterType<AuditConsumer>().AsSelf().InstancePerRequest();



            // Build container
            var container = builder.Build();

            // Web API dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver(container);

            // Register event subscriptions
            EventConsumerRegistration.Register(container);
        }
    }
}