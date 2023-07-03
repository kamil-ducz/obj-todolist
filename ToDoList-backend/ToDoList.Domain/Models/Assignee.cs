using System.Collections.Generic;

namespace ToDoList.Domain.Models;

public class Assignee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<BucketTask> BucketTask { get; set; } = new List<BucketTask>();
}
