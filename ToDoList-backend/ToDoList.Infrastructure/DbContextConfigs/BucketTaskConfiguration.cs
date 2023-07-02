using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketTaskConfiguration : IEntityTypeConfiguration<BucketTask>
{
    public void Configure(EntityTypeBuilder<BucketTask> builder)
    {
        builder.HasData(
            new BucketTask { Id = 1, BucketsId = 1, Name = "1:1 leader", BucketTaskPriorityId = 1, BucketTaskStateId = 1 },
            new BucketTask { Id = 2, BucketsId = 1, Name = "Organize desk", BucketTaskPriorityId = 2, BucketTaskStateId = 2 },
            new BucketTask { Id = 3, BucketsId = 2, Name = "Water plants", BucketTaskPriorityId = 3, BucketTaskStateId = 3 },
            new BucketTask { Id = 4, BucketsId = 2, Name = "Clean bedroom", BucketTaskPriorityId = 1, BucketTaskStateId = 4 },
            new BucketTask { Id = 5, BucketsId = 3, Name = "Organize diet", BucketTaskPriorityId = 2, BucketTaskStateId = 3 },
            new BucketTask { Id = 6, BucketsId = 3, Name = "Training plan", BucketTaskPriorityId = 3, BucketTaskStateId = 2 }
        );
    }
}