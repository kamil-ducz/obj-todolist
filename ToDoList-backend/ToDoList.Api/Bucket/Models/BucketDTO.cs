using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Domain.Enums;

namespace ToDoList.Api.Bucket.Models;

public record BucketDto(int Id, string Name, string? Description, Category Category, BucketColor BucketColor,
                       bool IsActive, List<BucketTaskDto> BucketTasks, int MaxAmountOfTasks = 1);
