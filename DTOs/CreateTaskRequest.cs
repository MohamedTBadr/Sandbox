using Sandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.DTOs
{
    public class CreateTaskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }

        public Guid UserId { get; set; }
    }
}