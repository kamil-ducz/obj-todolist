namespace ToDoList.Api.BucketTasks.Models;

public record BucketTaskDto(int Id, string Name, string? Description, int BucketTaskStateId, int BucketTaskPriorityId, int BucketId, int AssigneeId);