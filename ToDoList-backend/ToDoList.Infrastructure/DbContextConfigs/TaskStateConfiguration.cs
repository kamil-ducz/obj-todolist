using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;

public class TaskStateConfiguration : IEntityTypeConfiguration<TaskState>
{
    public void Configure(EntityTypeBuilder<TaskState> builder)
    {
        builder.HasData(
            new TaskState { Id = (int)Domain.Enums.TaskState.ToDo, Name = "To Do" },
            new TaskState { Id = (int)Domain.Enums.TaskState.InProgress, Name = "In Progress" },
            new TaskState { Id = (int)Domain.Enums.TaskState.Done, Name = "Done" },
            new TaskState { Id = (int)Domain.Enums.TaskState.Cancelled, Name = "Cancelled" }
        );
    }
}