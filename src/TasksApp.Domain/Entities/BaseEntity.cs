namespace TasksApp.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; } = new Guid();
}