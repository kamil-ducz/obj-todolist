using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class AssigneeConfiguration : IEntityTypeConfiguration<Assignees>
{
    public void Configure(EntityTypeBuilder<Assignees> builder)
    {
        builder.HasData(
            new Assignees { Id = 1, Name = "John Doe" }
        );
    }
}
