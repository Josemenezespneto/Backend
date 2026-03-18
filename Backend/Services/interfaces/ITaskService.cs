using System;
using Backend.Models;

namespace Backend.Services
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> GetById(int id);
        Task<TaskModel> CreateTask(CreateTaskDto task);
        Task<TaskModel> UpdateTask(UpdateTaskDto task, int id);
        Task<bool> DeleteTask(int id);
    }
}

