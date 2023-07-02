using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Enums;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketTaskPriorityConfiguration : IEntityTypeConfiguration<BucketTaskPriority>
{
    public void Configure(EntityTypeBuilder<BucketTaskPriority> builder)
    {
        builder.HasData(
            new BucketTaskPriority() { Id = 1, Name = "High" },
            new BucketTaskPriority() { Id = 2, Name = "Normal" },
            new BucketTaskPriority() { Id = 3, Name = "Low" }
            );
    }
}
