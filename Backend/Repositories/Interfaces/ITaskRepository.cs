using System;
using Backend.Models;

namespace Backend.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAll();
        Task<TaskModel> GetById(int id);
        Task<TaskModel> Add(TaskModel task);
        Task<TaskModel> Update(TaskModel task);
        Task<bool> Delete(TaskModel task);
    }
}

