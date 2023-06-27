using FluentValidation;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Api.BucketTask.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.BucketTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BucketTaskController : ControllerBase
{
    private readonly IBucketTaskService _bucketTaskService;
    private readonly IValidator<BucketUpsertTaskDto> _bucketInsertTaskDtoValidator;

    public BucketTaskController(IBucketTaskService bucketTaskService, IValidator<BucketUpsertTaskDto> bucketInsertTaskDtoValidator)
    {
        _bucketTaskService = bucketTaskService;
        _bucketInsertTaskDtoValidator = bucketInsertTaskDtoValidator;
    }

    [HttpGet]
    public IEnumerable<BucketTaskDto> Get()
    {
        return _bucketTaskService.GetBucketTasks();
    }

    [HttpGet("{id}")]
    public BucketTaskDto Get(int id)
    {
        return _bucketTaskService.GetBucketTask(id);
    }

    [HttpPost]
    public IActionResult Post(BucketUpsertTaskDto bucketInsertTaskDto)
    {
        _bucketInsertTaskDtoValidator.ValidateAndThrow(bucketInsertTaskDto);
        var bucketTaskId = _bucketTaskService.InsertBucketTask(bucketInsertTaskDto);

        return Created(Request.GetEncodedUrl() + "/" + bucketTaskId, bucketInsertTaskDto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, BucketUpsertTaskDto bucketTaskDto)
    {
        _bucketInsertTaskDtoValidator.ValidateAndThrow(bucketTaskDto);
        _bucketTaskService.UpdateBucketTask(id, bucketTaskDto);

        return Ok(bucketTaskDto);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _bucketTaskService.DeleteBucketTask(id);

        return NoContent();
    }
}
