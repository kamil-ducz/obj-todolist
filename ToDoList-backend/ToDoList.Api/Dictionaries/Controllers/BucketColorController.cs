using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Dictionaries.Services;

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

    [HttpGet]
    public int GetBucketColorIdByName(string bucketColorName)
    {
        return _bucketColorService.GetBucketColorIdByName(bucketColorName);
    }

    [HttpGet("{bucketColorId}")]
    public string GetBucketColorNameById(int bucketColorId)
    {
        return _bucketColorService.GetBucketColorNameById(bucketColorId);
    }
}
