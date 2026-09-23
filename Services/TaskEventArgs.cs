using Sandbox.Models;
using System;

namespace Sandbox.Services
{
    public class TaskEventArgs : EventArgs
    {
        public Task Task { get; }

        public TaskEventArgs(Task task)
        {
            Task = task;
        }
    }
}