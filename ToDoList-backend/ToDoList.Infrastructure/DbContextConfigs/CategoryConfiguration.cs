using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Enums;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class CategoryConfiguration : IEntityTypeConfiguration<BucketCategory>
{
    public void Configure(EntityTypeBuilder<BucketCategory> builder)
    {
        builder.HasData(
            new BucketCategory() { Id = 1, Name = "Work" },
            new BucketCategory() { Id = 2, Name = "Home" },
            new BucketCategory() { Id = 3, Name = "Hobby" }
        );
    }
}
