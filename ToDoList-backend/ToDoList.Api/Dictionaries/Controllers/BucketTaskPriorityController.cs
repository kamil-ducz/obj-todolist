using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Dictionaries.Services;
using ToDoList.Domain.Enums;

namespace ToDoList.Api.Dictionaries.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BucketTaskPriorityController : Controller
{
    private readonly IBucketTaskPriorityService _bucketTaskPriorityService;

    public BucketTaskPriorityController(IBucketTaskPriorityService bucketTaskPriorityService)
    {
        _bucketTaskPriorityService = bucketTaskPriorityService;
    }
    [HttpGet("all")]
    public IReadOnlyCollection<BucketTaskPriority> GetAllBucketTaskPriorities()
    {
        return _bucketTaskPriorityService.GetBucketTaskPriorities();
    }
}
