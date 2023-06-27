using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Asignee.Models;

public record AssigneeDto(int Id, string Name, List<BucketTaskDto> BucketTasks);