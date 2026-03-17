using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<List<TaskModel>> GetAllTasks()
    {
        return await _taskRepository.GetAll();
    }

    public async Task<TaskModel> GetById(int id)
    {
        var taskFound = await _taskRepository.GetById(id);

        if (taskFound == null)
            throw new KeyNotFoundException($"Task com Id {id} não encontrado");

        return taskFound;
    }

    public async Task<TaskModel> CreateTask(TaskModel task)
    {
        return await _taskRepository.Add(task);
    }

    public async Task<TaskModel> UpdateTask(TaskModel task, int id)
    {
        var taskFound = await _taskRepository.GetById(id);

        if (taskFound == null)
            throw new KeyNotFoundException($"Task com Id {id} não encontrado");

        taskFound.Name = task.Name;
        taskFound.Description = task.Description;
        taskFound.Status = task.Status;
        taskFound.UserId = task.UserId;

        return await _taskRepository.Update(taskFound);
    }

    public async Task<bool> DeleteTask(int id)
    {
        var taskFound = await _taskRepository.GetById(id);

        if (taskFound == null)
            throw new KeyNotFoundException($"Task com Id {id} não encontrado");

        return await _taskRepository.Delete(taskFound);
    }
}