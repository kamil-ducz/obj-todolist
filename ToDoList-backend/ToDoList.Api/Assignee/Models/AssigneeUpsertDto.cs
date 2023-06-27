using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Asignee.Models;

public class AssigneeUpsertDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<BucketTaskDto> BucketTasks { get; set; } = new List<BucketTaskDto>();
}
