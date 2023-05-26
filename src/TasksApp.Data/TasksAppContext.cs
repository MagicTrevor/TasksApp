using Microsoft.EntityFrameworkCore;
using TasksApp.Data.Configurations;
using TasksApp.Domain.Entities;

namespace TasksApp.Data;

public class TasksAppContext : DbContext
{
    public TasksAppContext(DbContextOptions<TasksAppContext> options) : base(options)
    {}

    public DbSet<TaskItem> TaskItems => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskItemConfiguration());
    }
}
