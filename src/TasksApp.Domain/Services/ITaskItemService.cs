using TasksApp.Domain.Entities;

namespace TasksApp.Domain.Services;

public interface ITaskItemService
{
    /// <summary>
    /// Gets an existing <see cref="TaskItem" /> for the given id if it exists
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TaskItem?> GetAsync(Guid id);

    /// <summary>
    /// Gets all existing <see cref="TaskItem" />s
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TaskItem>> GetAllAsync();

    /// <summary>
    /// Creates a new <see cref="TaskItem" />
    /// </summary>
    /// <param name="taskItem"></param>
    /// <returns></returns>
    Task<TaskItem> CreateAsync(TaskItem taskItem);

    /// <summary>
    /// Updates the description for a given <see cref="TaskItem" />
    /// </summary>
    /// <param name="id"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    Task<TaskItem?> UpdateDescription(Guid id, string description);

    /// <summary>
    /// Marks an existing <see cref="TaskItem" /> as complete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TaskItem?> MarkComplete(Guid id);
}