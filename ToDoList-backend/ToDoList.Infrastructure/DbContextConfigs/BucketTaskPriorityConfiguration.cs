using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketTaskPriorityConfiguration : IEntityTypeConfiguration<BucketTaskPriority>
{
    public void Configure(EntityTypeBuilder<BucketTaskPriority> builder)
    {
        builder.HasData(
            new BucketTaskPriority() { Id = (int)Domain.Enums.BucketTaskPriority.High, Name = "High" },
            new BucketTaskPriority() { Id = (int)Domain.Enums.BucketTaskPriority.Normal, Name = "Medium" },
            new BucketTaskPriority() { Id = (int)Domain.Enums.BucketTaskPriority.Low, Name = "Low" }
            );
    }
}
