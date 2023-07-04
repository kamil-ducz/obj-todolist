using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Dictionaries.Services;
using ToDoList.Domain.Models;

namespace ToDoList.Api.Dictionaries.Controllers;
[Route("api/[controller]")]
[ApiController]

public class DictionaryController : Controller
{
    private readonly IDictionaryService _dictionaryService;

    public DictionaryController(IDictionaryService dictionaryService)
    {
        _dictionaryService = dictionaryService;
    }

    [HttpGet("bucketCategories/all")]
    public IReadOnlyCollection<BucketCategory> GetAllBucketCategories()
    {
        return _dictionaryService.GetAll<BucketCategory>();
    }

    [HttpGet("bucketColors/all")]
    public IReadOnlyCollection<BucketColor> GetAllBucketColors()
    {
        return _dictionaryService.GetAll<BucketColor>();
    }

    [HttpGet("bucketTaskStates/all")]
    public IReadOnlyCollection<BucketTaskState> GetAllBucketTasks()
    {
        return _dictionaryService.GetAll<BucketTaskState>();
    }

    [HttpGet("bucketTaskPriorities/all")]
    public IReadOnlyCollection<BucketTaskPriority> GetAllBucketTasksPriorities()
    {
        return _dictionaryService.GetAll<BucketTaskPriority>();
    }
}
