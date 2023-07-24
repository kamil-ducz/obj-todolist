using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketTaskConfiguration : IEntityTypeConfiguration<BucketTask>
{
    public void Configure(EntityTypeBuilder<BucketTask> builder)
    {
        builder.HasData(
            new BucketTask { Id = 1, Name = "1:1 leader", BucketTaskStateId = (int)Domain.Enums.BucketTaskState.ToDo, BucketTaskPriorityId = (int)Domain.Enums.BucketTaskPriority.Low, BucketId = 1, AssigneeId = 1 },
            new BucketTask { Id = 2, Name = "Organize desk", BucketTaskStateId = (int)Domain.Enums.BucketTaskState.Done, BucketTaskPriorityId = (int)Domain.Enums.BucketTaskPriority.Normal, BucketId = 1, AssigneeId = 2 },
            new BucketTask { Id = 3, Name = "Water plants", BucketTaskStateId = (int)Domain.Enums.BucketTaskState.Cancelled, BucketTaskPriorityId = (int)Domain.Enums.BucketTaskPriority.High, BucketId = 2, AssigneeId = 3 },
            new BucketTask { Id = 4, Name = "Clean bedroom", BucketTaskStateId = (int)Domain.Enums.BucketTaskState.InProgress, BucketTaskPriorityId = (int)Domain.Enums.BucketTaskPriority.High, BucketId = 2, AssigneeId = 4 },
            new BucketTask { Id = 5, Name = "Organize diet", BucketTaskStateId = (int)Domain.Enums.BucketTaskState.ToDo, BucketTaskPriorityId = (int)Domain.Enums.BucketTaskPriority.High, BucketId = 3, AssigneeId = 5 },
            new BucketTask { Id = 6, Name = "Training plan", BucketTaskStateId = (int)Domain.Enums.BucketTaskState.Done, BucketTaskPriorityId = (int)Domain.Enums.BucketTaskPriority.Normal, BucketId = 3, AssigneeId = 6 }
        );
    }
}