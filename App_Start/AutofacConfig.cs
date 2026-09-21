using Autofac;
using Sandbox.Models;
using Sandbox.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        }
    }
}