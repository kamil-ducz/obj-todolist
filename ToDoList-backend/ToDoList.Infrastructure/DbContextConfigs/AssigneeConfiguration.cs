using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class AssigneeConfiguration : IEntityTypeConfiguration<Assignee>
{
    public void Configure(EntityTypeBuilder<Assignee> builder)
    {
        builder.HasData(
            new Assignee { Id = 1, Name = "John Doe" },
            new Assignee { Id = 2, Name = "Otobong Shay" },
            new Assignee { Id = 3, Name = "Pilirani Tendai" },
            new Assignee { Id = 4, Name = "Jess Blue" },
            new Assignee { Id = 5, Name = "Beck Itumeleng" },
            new Assignee { Id = 6, Name = "Radha Mpho" },
            new Assignee { Id = 7, Name = "Chikelu Tshepo" },
            new Assignee { Id = 8, Name = "Amal Yu" },
            new Assignee { Id = 9, Name = "Sasha Tristin" },
            new Assignee { Id = 10, Name = "Lee Lihuén" }
        );
    }
}
