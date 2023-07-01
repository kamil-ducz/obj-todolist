using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;

public class TaskPriorityConfiguration : IEntityTypeConfiguration<TaskPriority>
{
    public void Configure(EntityTypeBuilder<TaskPriority> builder)
    {
        builder.HasData(
            new TaskPriority { Id = (int)Domain.Enums.TaskPriority.High, Name = "High" },
            new TaskPriority { Id = (int)Domain.Enums.TaskPriority.Normal, Name = "Normal" },
            new TaskPriority { Id = (int)Domain.Enums.TaskPriority.Low, Name = "Low" }
        );
    }
}