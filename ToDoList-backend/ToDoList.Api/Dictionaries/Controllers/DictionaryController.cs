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

    [HttpGet("bucketCategories")]
    public IReadOnlyCollection<BucketCategory> GetAllBucketCategories()
    {
        return _dictionaryService.GetAll<BucketCategory>();
    }

    [HttpGet("bucketColors")]
    public IReadOnlyCollection<BucketColor> GetAllBucketColors()
    {
        return _dictionaryService.GetAll<BucketColor>();
    }

    [HttpGet("bucketTaskStates")]
    public IReadOnlyCollection<BucketTaskState> GetAllBucketTasks()
    {
        return _dictionaryService.GetAll<BucketTaskState>();
    }

    [HttpGet("bucketTaskPriorities")]
    public IReadOnlyCollection<BucketTaskPriority> GetAllBucketTasksPriorities()
    {
        return _dictionaryService.GetAll<BucketTaskPriority>();
    }
}
