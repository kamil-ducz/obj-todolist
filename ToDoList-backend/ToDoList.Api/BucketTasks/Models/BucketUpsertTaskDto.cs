namespace ToDoList.Api.BucketTasks.Models;

public record BucketUpsertTaskDto(string Name, string? Description, int BucketTaskStateId, int BucketTaskPriorityId, int BucketId, int AssigneeId);
