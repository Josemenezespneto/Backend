using Backend.Data;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class TaskRepository : ITaskRepository
{
    private readonly DatabaseContext _dbContext;

    public TaskRepository(DatabaseContext context)
    {
        _dbContext = context;
    }

    public async Task<List<TaskModel>> GetAll()
    {
        return await _dbContext.Tasks
            .AsNoTracking()
            .Include(x => x.User)
            .ToListAsync();
    }

    public async Task<TaskModel> GetById(int id)
    {
        return await _dbContext.Tasks
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TaskModel> Add(TaskModel task)
    {
        await _dbContext.Tasks.AddAsync(task);
        await _dbContext.SaveChangesAsync();
        return task;
    }

    public async Task<TaskModel> Update(TaskModel task)
    {
     
        _dbContext.Tasks.Update(task);
        await _dbContext.SaveChangesAsync();

        return task;
    }

    public async Task<bool> Delete(TaskModel task)
    {
        _dbContext.Tasks.Remove(task);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}