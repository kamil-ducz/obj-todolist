using System.Collections.Generic;
using ToDoList.Api.Asignee.Models;
using ToDoList.Domain.Enums;

namespace ToDoList.Api.BucketTask.Models;

public record BucketTaskDto(int Id, string Name, string? Description, TaskState TaskState,
                            TaskPriority TaskPriority, int BucketId, List<AssigneeDto> Assignees);
