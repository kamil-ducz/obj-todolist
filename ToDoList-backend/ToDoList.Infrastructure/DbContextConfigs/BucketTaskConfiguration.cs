using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketTaskConfiguration : IEntityTypeConfiguration<BucketTask>
{
    public void Configure(EntityTypeBuilder<BucketTask> builder)
    {
        builder.HasData(
            new BucketTask { Id = 1, BucketsId = 1, Name = "Speak to manager", TaskStateId = Domain.Enums.TaskState.ToDo },
            new BucketTask { Id = 2, BucketsId = 1, Name = "Organize desk", TaskStateId = Domain.Enums.TaskState.InProgress },
            new BucketTask { Id = 3, BucketsId = 2, Name = "Water plants", TaskStateId = Domain.Enums.TaskState.Cancelled },
            new BucketTask { Id = 4, BucketsId = 2, Name = "Clean bedroom", TaskStateId = Domain.Enums.TaskState.Done },
            new BucketTask { Id = 5, BucketsId = 3, Name = "Organize diet", TaskStateId = Domain.Enums.TaskState.Done },
            new BucketTask { Id = 6, BucketsId = 3, Name = "Update training plan", TaskStateId = Domain.Enums.TaskState.InProgress }
        );
    }
}