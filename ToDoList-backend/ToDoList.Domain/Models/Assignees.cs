using System.Collections.Generic;

namespace ToDoList.Domain.Models;

public class Assignees
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<BucketTasks> BucketTasks { get; set; } = new List<BucketTasks>();
}
