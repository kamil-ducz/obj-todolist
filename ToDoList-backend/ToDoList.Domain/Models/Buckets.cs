using System.Collections.Generic;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Models;

public class Buckets
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Category Category { get; set; }
    public BucketColor BucketColor { get; set; }
    public int MaxAmountOfTasks { get; set; }
    public bool IsActive { get; set; }
    public List<BucketTasks> BucketTasks { get; set; } = new List<BucketTasks>();
}
