using FluentValidation;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Api.BucketTasks.Services;

namespace ToDoList.Api.BucketTasks.Controllers;

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
    public IReadOnlyCollection<BucketTaskDto> Get()
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

        return Created(Request.GetEncodedUrl() + "/" + bucketTaskId, _bucketTaskService.GetBucketTask(bucketTaskId));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, BucketUpsertTaskDto bucketTaskDto)
    {
        _bucketInsertTaskDtoValidator.ValidateAndThrow(bucketTaskDto);
        _bucketTaskService.UpdateBucketTask(id, bucketTaskDto);

        return Ok(_bucketTaskService.GetBucketTask(id));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _bucketTaskService.DeleteBucketTask(id);

        return NoContent();
    }
}
