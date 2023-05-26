using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksApp.Data;
using TasksApp.Data.Repositories;
using TasksApp.Domain.Entities;
using Xunit;

namespace TasksApp.Tests.Repositories;

public class TaskItemRepositoryTests
{
    private DbContextOptions<TasksAppContext> _dbContextOptions;

    private Guid _testGuid;

    public TaskItemRepositoryTests()
    {
        var databaseName = $"TasksApp_{DateTime.Now.ToFileTimeUtc()}";
        _dbContextOptions = new DbContextOptionsBuilder<TasksAppContext>()
            .UseInMemoryDatabase(databaseName)
            .Options;
    }

    [Fact]
    public async Task GetAllAsync_Success()
    {
        //arrange
        var repository = await CreateTestRepositoryAsync();

        //act
        var taskItemsList = await repository.GetAllAsync();

        //assert
        Assert.Equal(3, taskItemsList.Count());
    }

    [Fact]
    public async Task GetAsync_Success()
    {
        //arrange
        var repository = await CreateTestRepositoryAsync();

        //act
        var taskItem = await repository.GetAsync(_testGuid);

        //assert
        Assert.NotNull(taskItem);
        Assert.Equal(_testGuid, taskItem!.Id);
    }

    [Fact]
    public async Task CreateAsync_Success()
    {
        //arrange
        var repository = await CreateTestRepositoryAsync();

        //act
        await repository.CreateAsync(new TaskItem("TestCreate"));

        //assert
        var taskItemsList = await repository.GetAllAsync();
        Assert.Equal(4, taskItemsList.Count());
    }

    [Fact]
    public async Task UpdateAsync_Success()
    {
        //arrange
        var repository = await CreateTestRepositoryAsync();
        var taskItem = await repository.GetAsync(_testGuid);
        taskItem!.SetDescription("UpdateTest");

        //act
        await repository.UpdateAsync(taskItem);

        //assert
        Assert.Equal("UpdateTest", taskItem.Description);
    }

    /// <summary>
    /// Creates and returns a new <see cref="TaskItemRepository" /> instance for testing
    /// </summary>
    /// <returns></returns>
    private async Task<TaskItemRepository> CreateTestRepositoryAsync()
    {
        var context = new TasksAppContext(_dbContextOptions);
        await SeedTestDataAsync(context);
        return new TaskItemRepository(context);
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
        context.ChangeTracker.Clear();

        _testGuid = taskItemsToSeed.First().Id;
    }
}