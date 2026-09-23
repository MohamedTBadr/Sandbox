using Autofac;
using Sandbox.Consumers;
using Sandbox.Services;

namespace Sandbox.App_Start
{
    public static class EventConsumerRegistration
    {
        public static void Register(
            IComponentContext context)
        {
            var taskService =
                context.Resolve<TaskService>();
            var auditConsumer =
                context.Resolve<AuditConsumer>();
            taskService.TaskCreated += auditConsumer.Handle;


        }
    }
}