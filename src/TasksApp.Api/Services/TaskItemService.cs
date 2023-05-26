using TasksApp.Domain.Entities;
using TasksApp.Domain.Repositories;
using TasksApp.Domain.Services;

namespace TasksApp.Api.Services;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _repository;

    public TaskItemService(ITaskItemRepository repository)
    {
        _repository = repository;
    }

    /// <inheritdoc/>
    public async Task<TaskItem?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    /// <inheritdoc/>
    public async Task<TaskItem> CreateAsync(TaskItem taskItem)
    {
        return await _repository.CreateAsync(taskItem);
    }

    /// <inheritdoc/>
    public async Task<TaskItem?> UpdateDescription(Guid id, string description)
    {
        var taskItem = await _repository.GetAsync(id);
        if (taskItem is null)
        {
            return null;
        }

        taskItem.SetDescription(description);

        await _repository.UpdateAsync(taskItem);

        return taskItem;
    }

    /// <inheritdoc/>
    public async Task<TaskItem?> MarkComplete(Guid id)
    {
        var taskItem = await _repository.GetAsync(id);
        if (taskItem is null)
        {
            return null;
        }

        taskItem.CompleteTaskItem();

        await _repository.UpdateAsync(taskItem);

        return taskItem;
    }
}