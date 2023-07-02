using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Enums;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketTaskStateConfiguration : IEntityTypeConfiguration<BucketTaskState>
{
    public void Configure(EntityTypeBuilder<BucketTaskState> builder)
    {
        builder.HasData(
            new BucketTaskState() { Id = 1, Name = "To do" },
            new BucketTaskState() { Id = 2, Name = "In progress" },
            new BucketTaskState() { Id = 3, Name = "Done" },
            new BucketTaskState() { Id = 4, Name = "Cancelled" }
            );
    }
}