using System.Collections.Generic;
using FluentValidation;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Buckets.Models;
using ToDoList.Api.Buckets.Services;
using ToDoList.Api.BucketTasks.Models;

namespace ToDoList.Api.Buckets.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BucketController : ControllerBase
{
    private readonly IBucketService _bucketService;
    private readonly IValidator<BucketUpsertDto> _bucketUpsertDtoValidator;

    public BucketController(IBucketService bucketService, IValidator<BucketUpsertDto> bucketUpsertDtoValidator)
    {
        _bucketService = bucketService;
        _bucketUpsertDtoValidator = bucketUpsertDtoValidator;
    }

    [HttpGet]
    public IReadOnlyCollection<BucketDto> Get()
    {
        return _bucketService.GetAllBuckets();
    }

    [HttpGet("{id}")]
    public BucketDto Get(int id)
    {
        return _bucketService.GetBucket(id);
    }

    [HttpGet("buckettask/{bucketId}")]
    public IReadOnlyCollection<BucketTaskDto> Get(int bucketId, bool? cloghole)
    {
        return _bucketService.GetAllBucketsTasks(bucketId);
    }

    [HttpPost]
    public IActionResult Post(BucketUpsertDto bucketInsertDto)
    {
        _bucketUpsertDtoValidator.ValidateAndThrow(bucketInsertDto);
        var bucketId = _bucketService.InsertBucket(bucketInsertDto);

        return Created(Request.GetEncodedUrl() + "/" + bucketId, _bucketService.GetBucket(bucketId));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, BucketUpsertDto bucketInsertDto)
    {
        _bucketUpsertDtoValidator.ValidateAndThrow(bucketInsertDto);
        _bucketService.UpdateBucket(id, bucketInsertDto);

        return Ok(_bucketService.GetBucket(id));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _bucketService.DeleteBucket(id);

        return NoContent();
    }
}
