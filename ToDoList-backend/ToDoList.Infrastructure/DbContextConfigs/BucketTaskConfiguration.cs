using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketTaskConfiguration : IEntityTypeConfiguration<BucketTask>
{
    public void Configure(EntityTypeBuilder<BucketTask> builder)
    {
        builder.HasData(
            new BucketTask { Id = 1, BucketId = 1, Name = "1:1 leader", BucketTaskPriorityId = (int)Domain.Enums.BucketTaskPriority.Low, BucketTaskStateId = Domain.Enums.BucketTaskState.ToDo },
            new BucketTask { Id = 2, BucketId = 1, Name = "Organize desk", BucketTaskPriorityId = (int)Domain.Enums.BucketTaskPriority.Normal, BucketTaskStateId = Domain.Enums.BucketTaskState.Done },
            new BucketTask { Id = 3, BucketId = 2, Name = "Water plants", BucketTaskPriorityId = (int)Domain.Enums.BucketTaskPriority.High, BucketTaskStateId = Domain.Enums.BucketTaskState.Cancelled },
            new BucketTask { Id = 4, BucketId = 2, Name = "Clean bedroom", BucketTaskPriorityId = (int)Domain.Enums.BucketTaskPriority.High, BucketTaskStateId = Domain.Enums.BucketTaskState.InProgress },
            new BucketTask { Id = 5, BucketId = 3, Name = "Organize diet", BucketTaskPriorityId = (int)Domain.Enums.BucketTaskPriority.High, BucketTaskStateId = Domain.Enums.BucketTaskState.ToDo },
            new BucketTask { Id = 6, BucketId = 3, Name = "Training plan", BucketTaskPriorityId = (int)Domain.Enums.BucketTaskPriority.Normal, BucketTaskStateId = Domain.Enums.BucketTaskState.Done }
        );
    }
}