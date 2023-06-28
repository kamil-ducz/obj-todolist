using System.Collections.Generic;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Models;

public class BucketTasks
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TaskState TaskState { get; set; }
    public TaskPriority TaskPriority { get; set; }
    public int BucketsId { get; set; }
    public List<Assignees> Assignees { get; set; } = new List<Assignees>();
}
