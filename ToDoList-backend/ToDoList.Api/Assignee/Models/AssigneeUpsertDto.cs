using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Assignee.Models;

public class AssigneeUpsertDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<BucketTaskDto> BucketTask { get; set; } = new List<BucketTaskDto>();
}
