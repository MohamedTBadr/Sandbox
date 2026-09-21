using Sandbox.DTOs;
using Sandbox.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskModel= Sandbox.Models.Task;
using Task = System.Threading.Tasks.Task;

namespace Sandbox.Services
{
    public interface ITaskService
    {
        Task CreateTask(CreateTaskRequest request, Guid UserId);
        Task<IEnumerable<TaskModel>> GetTasks(Guid userId,int pageIndex,int pageSize=10);
        Task<TaskModel> GetTaskById(Guid id,Guid userId);
        Task UpdateTask(Guid id, UpdateTaskRequest request, Guid userId);
        Task DeleteTask(Guid id ,Guid userId);
    }
}