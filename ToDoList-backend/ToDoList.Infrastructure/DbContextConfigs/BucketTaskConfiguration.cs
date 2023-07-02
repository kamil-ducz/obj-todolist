using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketTaskConfiguration : IEntityTypeConfiguration<BucketTasks>
{
    public void Configure(EntityTypeBuilder<BucketTasks> builder)
    {
        builder.HasData(
            new BucketTasks { Id = 1, BucketsId = 1, Name = "Speak to manager", BucketTaskPriorityId = 1, TaskState = TaskState.ToDo },
            new BucketTasks { Id = 2, BucketsId = 1, Name = "Organize desk", BucketTaskPriorityId = 2, TaskState = TaskState.InProgress },
            new BucketTasks { Id = 3, BucketsId = 2, Name = "Water plants", BucketTaskPriorityId = 3, TaskState = TaskState.Cancelled },
            new BucketTasks { Id = 4, BucketsId = 2, Name = "Clean bedroom", BucketTaskPriorityId = 1, TaskState = TaskState.Done },
            new BucketTasks { Id = 5, BucketsId = 3, Name = "Organize diet", BucketTaskPriorityId = 2, TaskState = TaskState.Done },
            new BucketTasks { Id = 6, BucketsId = 3, Name = "Update training plan", BucketTaskPriorityId = 3, TaskState = TaskState.InProgress }
        );
    }
}