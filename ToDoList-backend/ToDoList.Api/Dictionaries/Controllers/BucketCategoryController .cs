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
    public int GetBucketCategoryIdByName(string bucketCategoryName)
    {
        return _bucketCategoryService.GetBucketCategoryIdByName(bucketCategoryName);
    }

    [HttpGet("{bucketCategoryId}")]
    public BucketCategory GetBucketCategoryNameById(int bucketCategoryId)
    {
        var bucketCategory = new BucketCategory();
        bucketCategory.Name = _bucketCategoryService.GetBucketCategoryNameById(bucketCategoryId);
        return bucketCategory;
    }
}
