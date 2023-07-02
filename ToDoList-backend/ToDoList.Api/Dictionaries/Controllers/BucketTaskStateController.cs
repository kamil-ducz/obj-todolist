using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Dictionaries.Services;
using ToDoList.Domain.Enums;

namespace ToDoList.Api.Dictionaries.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BucketTaskStateController : Controller
{
    private readonly IBucketTaskStateService _bucketTaskStateService;

    public BucketTaskStateController(IBucketTaskStateService bucketTaskStateService)
    {
        _bucketTaskStateService = bucketTaskStateService;
    }

    [HttpGet("all")]
    public IReadOnlyCollection<BucketTaskState> GetAllBucketTaskStates()
    {
        return _bucketTaskStateService.GetAllBucketTasksStates();
    }

}
