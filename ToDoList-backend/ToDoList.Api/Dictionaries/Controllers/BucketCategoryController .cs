using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Dictionaries.Services;
using ToDoList.Domain.Enums;

namespace ToDoList.Api.Dictionaries.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BucketCategoryController : ControllerBase
{
    private readonly IBucketCategoryService _bucketCategoryService;

    public BucketCategoryController(IBucketCategoryService bucketCategoryService)
    {
        _bucketCategoryService = bucketCategoryService;
    }

    [HttpGet]
    public BucketCategory GetBucketCategoryIdByName(string bucketCategoryName)
    {
        var bucket = new BucketCategory();
        bucket.Id = _bucketCategoryService.GetBucketCategoryIdByName(bucketCategoryName);
        return bucket;
    }

    [HttpGet("{bucketCategoryId}")]
    public BucketCategory GetBucketCategoryNameById(int bucketCategoryId)
    {
        var bucket = new BucketCategory();
        bucket.Name = _bucketCategoryService.GetBucketCategoryNameById(bucketCategoryId);
        return bucket;
    }
}
