using AutoMapper;
using FluentValidation;
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
    private readonly IValidator<BucketDto> _bucketDTOValidator;
    private readonly IMapper _mapper;

    public BucketController(IBucketService bucketService, IValidator<BucketDto> bucketDTOValidator, IMapper mapper)
    {
        _bucketService = bucketService;
        _bucketDTOValidator = bucketDTOValidator;
        _mapper = mapper;
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
    public IActionResult Post([FromBody] BucketDto bucketDTO)
    {
        _bucketDTOValidator.ValidateAndThrow(bucketDTO);

        var bucketId = _bucketService.InsertBucket(bucketDTO);

        return Ok(bucketDTO);

    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BucketDto bucketDTO)
    {
        _bucketDTOValidator.ValidateAndThrow(bucketDTO);

        _bucketService.UpdateBucket(id, bucketDTO);

        return Ok(bucketDTO);


    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var bucketToDelete = _bucketService.GetBucket(id);

        var mappedBucket = _mapper.Map<BucketDto>(bucketToDelete);

        _bucketDTOValidator.ValidateAndThrow(mappedBucket);

        _bucketService.DeleteBucket(id);

        return Ok(bucketToDelete);
    }
}
