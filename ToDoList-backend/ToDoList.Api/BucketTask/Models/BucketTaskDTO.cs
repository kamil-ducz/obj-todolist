using System.Collections.Generic;
using ToDoList.Api.Asignee.Models;
using ToDoList.Domain.Enums;

namespace ToDoList.Api.BucketTask.Models;

public class BucketTaskDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TaskState TaskState { get; set; }
    public BucketTaskPriority? BucketTaskPriority { get; set; }
    public int BucketTaskPriorityId { get; set; }
    public int BucketsId { get; set; }
    public List<AssigneeDto> Assignees { get; set; } = new List<AssigneeDto>();
}
