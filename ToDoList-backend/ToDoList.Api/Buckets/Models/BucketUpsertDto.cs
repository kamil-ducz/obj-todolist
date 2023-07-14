namespace ToDoList.Api.Buckets.Models;

public record BucketUpsertDto(
    string Name,
    string? Description,
    int BucketCategoryId,
    int BucketColorId,
    int MaxAmountOfTasks,
    bool IsActive
    );
