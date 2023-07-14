namespace ToDoList.Api.Buckets.Models;

public record BucketDto(
    int Id,
    string Name,
    string? Description,
    int BucketCategoryId,
    int BucketColorId,
    int MaxAmountOfTasks,
    bool IsActive
    );
