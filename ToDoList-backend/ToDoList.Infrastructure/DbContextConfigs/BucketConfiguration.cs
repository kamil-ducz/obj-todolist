using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.DbContextConfigs;
public class BucketConfiguration : IEntityTypeConfiguration<Bucket>
{
    public void Configure(EntityTypeBuilder<Bucket> builder)
    {
        var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
        if (projectDirectory is null)
        {
            throw new Exception("Error in data population. Could not retrieve basic directory of the application.");
        }
        var filePath = Path.Combine(projectDirectory, "ToDoList.Infrastructure", "DataPopulation", "bucket-population-data.json");
        var json = File.ReadAllText(filePath);
        var bucketsData = JsonConvert.DeserializeObject<List<Bucket>>(json);

        builder.HasData(
            bucketsData ?? new List<Bucket>()
        );
    }
}
