using System.Collections.Generic;

namespace ToDoList.Domain.Models;

public class BucketTask
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Enums.TaskState TaskStateId { get; set; }
    public TaskState TaskState { get; set; }
    public Enums.TaskState TaskPriorityId { get; set; }
    public TaskPriority TaskPriority { get; set; }
    public int BucketsId { get; set; }
    public List<Assignee> Assignees { get; set; } = new List<Assignee>();
}
