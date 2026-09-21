using Microsoft.AspNet.Identity;
using Sandbox.DTOs;
using Sandbox.Models;
using Sandbox.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

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
            return StatusCode(HttpStatusCode.Created);
        }


        [HttpGet]
        public IHttpActionResult GetTasks(int pageIndex, int pageSize = 10)
        {
                var userId = Guid.Parse(User.Identity.GetUserId());
            var tasks = _service.GetTasks(userId, pageIndex, pageSize);
                return Ok(tasks);
            
        }

        [HttpGet]
        public IHttpActionResult GetTaskById(Guid id)
        {
           
                var task = _service.GetTaskById(id, Guid.Parse(User.Identity.GetUserId()));
                if (task == null)
                {
                    return NotFound();
                }
                return Ok(task);
        }
        [HttpPut]
        public IHttpActionResult UpdateTask(Guid id, UpdateTaskRequest updateTaskRequest)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
           var task = _service.UpdateTask(id, updateTaskRequest, userId);
            return Ok(task);
        }

        [HttpDelete]
        public IHttpActionResult DeleteTask(Guid id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            _service.DeleteTask(id, userId);
            return StatusCode(HttpStatusCode.NoContent);
        }



    }
}