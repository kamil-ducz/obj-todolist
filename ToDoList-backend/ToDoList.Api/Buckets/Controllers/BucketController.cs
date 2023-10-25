using FluentValidation;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Buckets.Models;
using ToDoList.Api.Buckets.Services;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Domain.Models;

namespace ToDoList.Api.Buckets.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BucketController : ControllerBase
{
    private readonly IBucketService _bucketService;
    private readonly IValidator<BucketUpsertDto> _bucketInsertDtoValidator;

    public BucketController(IBucketService bucketService, IValidator<BucketUpsertDto> bucketInsertDtoValidator)
    {
        _bucketService = bucketService;
        _bucketInsertDtoValidator = bucketInsertDtoValidator;
    }

    [HttpGet("buckets")]
    public PaginatedBucketsResult Get([FromQuery] string? searchPhrase, [FromQuery] int currentPage = 1, [FromQuery] int itemsPerPage = 25)
    {
        return _bucketService.GetPaginatedBucketsResult(searchPhrase, currentPage, itemsPerPage);
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
        _bucketInsertDtoValidator.ValidateAndThrow(bucketInsertDto);
        var bucketId = _bucketService.InsertBucket(bucketInsertDto);

        return Created(Request.GetEncodedUrl() + "/" + bucketId, _bucketService.GetBucket(bucketId));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, BucketUpsertDto bucketInsertDto)
    {
        _bucketInsertDtoValidator.ValidateAndThrow(bucketInsertDto);
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
