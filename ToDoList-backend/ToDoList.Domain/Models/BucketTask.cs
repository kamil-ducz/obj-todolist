using System.Collections.Generic;

namespace ToDoList.Domain.Models;

public class BucketTask
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public BucketTaskState? BucketTaskState { get; set; }
    public Enums.BucketTaskState BucketTaskStateId { get; set; }
    public BucketTaskPriority? BucketTaskPriority { get; set; }
    public int BucketTaskPriorityId { get; set; }
    public int BucketId { get; set; }
    public List<Assignee> Assignee { get; set; } = new List<Assignee>();
}
