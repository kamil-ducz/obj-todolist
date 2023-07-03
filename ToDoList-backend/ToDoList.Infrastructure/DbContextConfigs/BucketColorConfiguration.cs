using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketColorConfiguration : IEntityTypeConfiguration<BucketColor>
{
    public void Configure(EntityTypeBuilder<BucketColor> builder)
    {
        builder.HasData(
            new BucketColor() { Id = 1, Name = "Brown" },
            new BucketColor() { Id = 2, Name = "Red" },
            new BucketColor() { Id = 3, Name = "Yellow" },
            new BucketColor() { Id = 4, Name = "Blue" },
            new BucketColor() { Id = 5, Name = "White" },
            new BucketColor() { Id = 6, Name = "Green" }
        );
    }
}