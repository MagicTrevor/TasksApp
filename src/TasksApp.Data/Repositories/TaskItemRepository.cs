using Microsoft.EntityFrameworkCore;
using TasksApp.Domain.Entities;
using TasksApp.Domain.Repositories;

namespace TasksApp.Data.Repositories;

public class TaskItemRepository : Repository<TaskItem>, ITaskItemRepository
{
    public TaskItemRepository(DbSet<TaskItem> taskItems) : base(taskItems)
    {}
}