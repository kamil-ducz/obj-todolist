using FluentValidation;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.Bucket.Models;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Api.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.Bucket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BucketController : ControllerBase
{
    private readonly IBucketService _bucketService;
    private readonly IValidator<BucketInsertDto> _bucketInsertDtoValidator;

    public BucketController(IBucketService bucketService, IValidator<BucketInsertDto> bucketInsertDtoValidator)
    {
        _bucketService = bucketService;
        _bucketInsertDtoValidator = bucketInsertDtoValidator;
    }

    [HttpGet]
    public IEnumerable<BucketDto> Get()

    {
        return _bucketService.GetAllBuckets();
    }

    [HttpGet("{id}")]
    public BucketDto Get(int id)
    {
        return _bucketService.GetBucket(id);
    }

    [HttpGet("buckettask/{id}")]
    public IEnumerable<BucketTaskDto> Get(int id, bool? cloghole)
    {
        return _bucketService.GetAllBucketsTasks(id).ToList();
    }

    [HttpPost]
    public IActionResult Post([FromBody] BucketInsertDto bucketInsertDto)
    {
        _bucketInsertDtoValidator.ValidateAndThrow(bucketInsertDto);

        var bucketId = _bucketService.InsertBucket(bucketInsertDto);

        return Created(Request.GetEncodedUrl() + "/" + bucketId, bucketInsertDto);

    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BucketInsertDto bucketInsertDto)
    {
        _bucketInsertDtoValidator.ValidateAndThrow(bucketInsertDto);

        _bucketService.UpdateBucket(id, bucketInsertDto);

        return Ok(bucketInsertDto);


    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _bucketService.DeleteBucket(id);

        return NoContent();
    }
}
