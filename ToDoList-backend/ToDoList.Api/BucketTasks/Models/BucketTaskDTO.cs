using System.Collections.Generic;
using ToDoList.Api.Assignees.Models;
using ToDoList.Domain.Models;

namespace ToDoList.Api.BucketTasks.Models;

public class BucketTaskDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public BucketTaskState? TaskState { get; set; }
    public int BucketTaskStateId { get; set; }
    public BucketTaskPriority? BucketTaskPriority { get; set; }
    public int BucketTaskPriorityId { get; set; }
    public int BucketId { get; set; }
    public List<AssigneeDto> Assignee { get; set; } = new List<AssigneeDto>();
}
