using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Dictionaries.Services;

namespace ToDoList.Api.Dictionaries.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BucketCategory : ControllerBase
{
    private readonly IBucketCategoryService _bucketCategoryService;

    public BucketCategory(IBucketCategoryService bucketCategoryService)
    {
        _bucketCategoryService = bucketCategoryService;
    }

    [HttpGet]
    public int GetBucketCategoryIdByName(string bucketCategoryName)
    {
        return _bucketCategoryService.GetBucketCategoryIdByName(bucketCategoryName);
    }

    [HttpGet("{bucketCategoryId}")]
    public string GetBucketCategoryNameById(int bucketCategoryId)
    {
        return _bucketCategoryService.GetBucketCategoryNameById(bucketCategoryId);
    }
}
