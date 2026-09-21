using Microsoft.AspNet.Identity;
using Sandbox.DTOs;
using Sandbox.Models;
using Sandbox.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Sandbox.Controllers
{
    [RoutePrefix("api/tasks")]
    public class TaskController : ApiController
    {
        private readonly ITaskService _service;
        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult CreateTask(CreateTaskRequest createTaskReqeust)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var task = _service.CreateTask(createTaskReqeust, userId);
            return Created($"api/tasks/{task.Id}", task);
        }


        [HttpGet]
        public IHttpActionResult GetTasks()
        {
                var userId = Guid.Parse(User.Identity.GetUserId());
            var tasks = _service.GetTasks(userId);
                return Ok(tasks);
            
        }

        [HttpGet]
        public IHttpActionResult GetTaskById(Guid id)
        {
           
                var task = _service.GetTaskById(id);
                if (task == null)
                {
                    return NotFound();
                }
                return Ok(task);
            
        }



    }
}