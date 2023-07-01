using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Dictionaries.Services;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Models;

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

    [HttpGet("all")]
    public IReadOnlyCollection<BucketCategory> GetAllBucketCategories()
    {
        return _bucketCategoryService.GetAllBucketCategories();
    }

    [HttpGet("name/{bucketCategoryName}")]
    public BucketCategory GetBucketCategoryIdByName(string bucketCategoryName)
    {
        var bucket = new BucketCategory
        {
            Id = _bucketCategoryService.GetBucketCategoryIdByName(bucketCategoryName)
        };
        return bucket;
    }

    [HttpGet("{bucketCategoryId}")]
    public BucketCategory GetBucketCategoryNameById(int bucketCategoryId)
    {
        var bucket = new BucketCategory
        {
            Name = _bucketCategoryService.GetBucketCategoryNameById(bucketCategoryId)
        };
        return bucket;
    }
}
