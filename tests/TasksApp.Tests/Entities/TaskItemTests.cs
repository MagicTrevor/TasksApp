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
    public void SetDescription_NullValue_NoChange()
    {
        //arrange
        var taskItem = new TaskItem("Test");

        //act
        taskItem.SetDescription("");

        //assert
        Assert.Equal("Test", taskItem.Description);
    }

    [Fact]
    public void SetDescription_LengthGreaterThan100_NoChange()
    {
        //arrange
        var taskItem = new TaskItem("Test");

        //act
        taskItem.SetDescription("mjQQWi7y4OY7z1UCQ7meWhaXKpAriHa5zCpWhjN6bO9APxuHIX6pPg55TwIQHYQxFzJk8DvnANpriNxfKmDpHwdwGmIMVnAhq1TeD");

        //assert
        Assert.Equal("Test", taskItem.Description);
    }

    [Fact]
    public void SetDescription_Valid_DescriptionIsSet()
    {
        //arrange
        var taskItem = new TaskItem("Test");

        //act
        taskItem.SetDescription("Test2");

        //assert
        Assert.Equal("Test2", taskItem.Description);
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