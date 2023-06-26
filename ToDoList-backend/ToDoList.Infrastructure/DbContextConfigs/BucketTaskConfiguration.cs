using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketTaskConfiguration : IEntityTypeConfiguration<BucketTask>
{
    public void Configure(EntityTypeBuilder<BucketTask> builder)
    {
        builder.HasData(
            new BucketTask { Id = 1, BucketId = 1, Name = "Speak to manager", TaskState = TaskState.ToDo },
            new BucketTask { Id = 2, BucketId = 1, Name = "Organize desk", TaskState = TaskState.InProgress },
            new BucketTask { Id = 3, BucketId = 2, Name = "Water plants", TaskState = TaskState.Cancelled },
            new BucketTask { Id = 4, BucketId = 2, Name = "Clean bedroom", TaskState = TaskState.Done },
            new BucketTask { Id = 5, BucketId = 3, Name = "Organize diet", TaskState = TaskState.Done },
            new BucketTask { Id = 6, BucketId = 3, Name = "Update training plan", TaskState = TaskState.InProgress }
        );
    }
}