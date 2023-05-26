using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasksApp.Domain.Entities;

namespace TasksApp.Data.Configurations;

public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(100);
    }
}