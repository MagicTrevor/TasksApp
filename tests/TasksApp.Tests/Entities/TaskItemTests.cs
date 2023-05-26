using System;
using TasksApp.Domain.Entities;
using Xunit;

namespace TasksApp.Tests.Entities;

public class TaskItemTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Constructor_NoDescription_ThrowsArgumentNullException(string description)
    {
        //arrange
        //act
        //assert
        Assert.Throws<ArgumentNullException>(() => new TaskItem(description));
    }

    [Fact]
    public void CompleteTaskItem_IsAlreadyComplete_NoChange()
    {
        //arrange
        var taskItem = new TaskItem("Test");
        taskItem.CompleteTaskItem();

        var completedDate = taskItem.CompletedDate;

        //act
        taskItem.CompleteTaskItem();

        //assert
        Assert.Equal(completedDate, taskItem.CompletedDate);
    }

    [Fact]
    public void CompleteTaskItem_IsNotComplete_SetsIsComplete()
    {
        //arrange
        var taskItem = new TaskItem("Test");
        var isComplete = taskItem.IsComplete;
        var completedDate = taskItem.CompletedDate;

        //act
        taskItem.CompleteTaskItem();

        //assert
        Assert.True(taskItem.IsComplete);
        Assert.NotEqual(isComplete, taskItem.IsComplete);
        Assert.NotEqual(completedDate, taskItem.CompletedDate);
    }
}