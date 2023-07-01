using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Dictionaries.Services;
using ToDoList.Domain.Enums;

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

    [HttpGet("name/{bucketColorName}")]
    public BucketColor GetBucketColorIdByName(string bucketColorName)
    {
        var bucket = new BucketColor
        {
            Id = _bucketColorService.GetBucketColorIdByName(bucketColorName)
        };
        return bucket;
    }

    [HttpGet("{bucketColorId}")]
    public BucketColor GetBucketColorNameById(int bucketColorId)
    {
        var bucket = new BucketColor
        {
            Name = _bucketColorService.GetBucketColorNameById(bucketColorId)
        };
        return bucket;
    }
}
