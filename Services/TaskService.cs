using Sandbox.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Sandbox.Models;
using Task = System.Threading.Tasks.Task;
using TaskModel = Sandbox.Models.Task;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
namespace Sandbox.Services
{
    public class TaskService : ITaskService
    {
        public event EventHandler<TaskEventArgs> TaskCreated;
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateTask(CreateTaskRequest request,Guid UserId)
        {
           
            var task = TaskModel.Create(request.Name, request.Description, request.Deadline,UserId);
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            OnTaskCreated(task);
        }

        public async Task<IEnumerable<TaskModel>> GetTasks(Guid userId, int pageIndex, int pageSize = 10)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId && t.DeletedAt == null)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(Guid id, Guid userId)
        {
           
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        }

    
        public async Task UpdateTask(Guid id, UpdateTaskRequest request, Guid userId, byte[] rowVersion)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            if (task != null)
            {
                _context.Entry(task)
                 .Property(t => t.RowVersion)
                  .OriginalValue = rowVersion;
                task.Update(request.Name, request.Description, request.Deadline);
                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteTask(Guid id, Guid userId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            if (task != null)
            {
                task.MarkAsDeleted();
                await _context.SaveChangesAsync();
            }
        }




        protected virtual void OnTaskCreated(TaskModel task)
        {
            TaskCreated?.Invoke(this, new TaskEventArgs(task));
        }
    }
}