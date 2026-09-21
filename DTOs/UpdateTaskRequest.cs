using System;

namespace Sandbox.DTOs
{
    public class UpdateTaskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}