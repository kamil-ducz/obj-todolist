using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Dictionaries.Services;
using ToDoList.Domain.Models;

namespace ToDoList.Api.Dictionaries.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BucketColorController : ControllerBase
{
    private readonly IBucketColorService _bucketColorService;

    public BucketColorController(IBucketColorService bucketColorService)
    {
        _bucketColorService = bucketColorService;
    }

    [HttpGet("all")]
    public IReadOnlyCollection<BucketColor> GetAllBucketColors()
    {
        return _bucketColorService.GetAllBucketColors();
    }
}
