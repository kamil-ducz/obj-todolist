using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Dictionaries.Services;
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
    public BucketCategory GetBucketCategoryByName(string bucketCategoryName)
    {
        return _bucketCategoryService.GetBucketCategoryByName(bucketCategoryName);
    }

    [HttpGet("{bucketCategoryId}")]
    public BucketCategory GetBucketCategoryById(int bucketCategoryId)
    {
        return _bucketCategoryService.GetBucketCategoryById(bucketCategoryId);
    }
}
