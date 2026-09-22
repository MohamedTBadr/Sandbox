using Microsoft.AspNet.Identity;
using Sandbox.Attributes;
using Sandbox.DTOs;
using Sandbox.Models;
using Sandbox.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
        public async Task<IHttpActionResult> CreateTask(CreateTaskRequest createTaskReqeust)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            await _service.CreateTask(createTaskReqeust, userId);
            return StatusCode(HttpStatusCode.Created);
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetTasks(int pageIndex, int pageSize = 10)
        {
                var userId = Guid.Parse(User.Identity.GetUserId());
            var tasks = await _service.GetTasks(userId, pageIndex, pageSize);
                return Ok(tasks);
            
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetTask(Guid id)
        {
            var task = await _service.GetTaskById(id, Guid.Parse(User.Identity.GetUserId()));

            if (task == null)
                return NotFound();

            var etag = Convert.ToBase64String(task.RowVersion);

            var response = Request.CreateResponse(HttpStatusCode.OK, new
            {
                task.Id,
                task.Name,
                task.Description,
                task.Deadline
            });

            response.Headers.ETag =
                new EntityTagHeaderValue($"\"{etag}\"");

            return ResponseMessage(response);
        }
        [HttpPut]
        [ETag]
        public async Task<IHttpActionResult> UpdateTask(Guid id, UpdateTaskRequest updateTaskRequest)
        {
            var rowVersion = (byte[])Request.Properties["RowVersion"];
            var userId = Guid.Parse(User.Identity.GetUserId());
            await _service.UpdateTask(id, updateTaskRequest, userId, rowVersion);
          return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteTask(Guid id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
           await _service.DeleteTask(id, userId);
            return StatusCode(HttpStatusCode.NoContent);
        }



    }
}