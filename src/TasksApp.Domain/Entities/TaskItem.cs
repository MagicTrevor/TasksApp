namespace TasksApp.Domain.Entities;

public class TaskItem : BaseEntity
{
    public string Description { get; private set; }
    public bool IsComplete { get; private set; }
    public DateTime CompletedDate { get; private set; }
    public DateTime CreatedDate { get; private set; }

    /// <summary>
    /// Default constructor for <see cref="TaskItem" />
    /// </summary>
    /// <param name="description"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public TaskItem(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentNullException(nameof(description), "Must include a description when creating a new TaskItem");
        }

        Description = description;
        IsComplete = false;

        CreatedDate = DateTime.Now;
    }

    /// <summary>
    /// Sets a new description
    /// </summary>
    /// <param name="description"></param>
    public void SetDescription(string description)
    {
        if (!string.IsNullOrWhiteSpace(description) && description.Length <= 100)
        {
            Description = description;
        }
    }

    /// <summary>
    /// Marks the <see cref="TaskItem" /> as complete
    /// </summary>
    public void CompleteTaskItem()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            CompletedDate = DateTime.Now;
        }
    }
}