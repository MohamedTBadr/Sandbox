using Sandbox.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.Consumers
{
    public class AuditConsumer
    {
        public void Handle(object sender, TaskEventArgs e)
        {
            var task = e.Task;
            
            Log.Information("Task {TaskId} has been created/updated/deleted. Name: {TaskName}, Description: {TaskDescription}, Deadline: {TaskDeadline}, UserId: {UserId}",
                task.Id, task.Name, task.Description, task.Deadline, task.UserId);

        }
    }
}