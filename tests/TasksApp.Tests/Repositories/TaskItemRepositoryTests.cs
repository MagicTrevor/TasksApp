using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksApp.Data;
using TasksApp.Data.Repositories;
using TasksApp.Domain.Entities;

namespace TasksApp.Tests.Repositories;

public class TaskItemRepositoryTests
{
    private DbContextOptions<TasksAppContext> _dbContextOptions;

    public TaskItemRepositoryTests()
    {
        var databaseName = $"TasksApp_{DateTime.Now.ToFileTimeUtc()}";
        _dbContextOptions = new DbContextOptionsBuilder<TasksAppContext>()
            .UseInMemoryDatabase(databaseName)
            .Options;
    }

    /// <summary>
    /// Creates and returns a new <see cref="TaskItemRepository" /> instance for testing
    /// </summary>
    /// <returns></returns>
    private async Task<TaskItemRepository> CreateTestRepositoryAsync()
    {
        var context = new TasksAppContext(_dbContextOptions);
        await SeedTestDataAsync(context);
        return new TaskItemRepository(context.TaskItems);
    }

    /// <summary>
    /// Seeds InMemory database with test data
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    private async Task SeedTestDataAsync(TasksAppContext context)
    {
        var taskItemsToSeed = new List<TaskItem>
        {
            new("Test"),
            new("Test2"),
            new("Test3")
        };

        await context.TaskItems.AddRangeAsync(taskItemsToSeed);
        await context.SaveChangesAsync();
    }
}