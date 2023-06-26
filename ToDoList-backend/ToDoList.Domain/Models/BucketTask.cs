using System.Collections.Generic;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Models;

public class BucketTask
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TaskState TaskState { get; set; }
    public TaskPriority TaskPriority { get; set; }

    public int BucketId { get; set; }
    public List<Assignee> Assignees { get; set; } = new List<Assignee>();
}
