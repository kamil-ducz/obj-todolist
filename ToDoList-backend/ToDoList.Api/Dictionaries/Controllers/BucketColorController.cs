using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Dictionaries.Models;
using ToDoList.Api.Dictionaries.Services;

namespace ToDoList.Api.Dictionaries.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BucketColorController : ControllerBase
{
    private readonly IDictionaryService _dictionaryService;

    public BucketColorController(IDictionaryService dictionaryService)
    {
        _dictionaryService = dictionaryService;
    }

    [HttpGet]
    public IReadOnlyCollection<BucketColorDto> GetAllBucketColors()
    {
        return _dictionaryService.GetBucketColors();
    }
}
