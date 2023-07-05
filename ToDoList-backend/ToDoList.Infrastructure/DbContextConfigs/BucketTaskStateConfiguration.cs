using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketTaskStateConfiguration : IEntityTypeConfiguration<BucketTaskState>
{
    public void Configure(EntityTypeBuilder<BucketTaskState> builder)
    {
        builder.HasData(
            new BucketTaskState() { Id = (int)Domain.Enums.BucketTaskState.ToDo, Name = "To do" },
            new BucketTaskState() { Id = (int)Domain.Enums.BucketTaskState.InProgress, Name = "In progress" },
            new BucketTaskState() { Id = (int)Domain.Enums.BucketTaskState.Done, Name = "Done" },
            new BucketTaskState() { Id = (int)Domain.Enums.BucketTaskState.Cancelled, Name = "Cancelled" }
            );
    }
}