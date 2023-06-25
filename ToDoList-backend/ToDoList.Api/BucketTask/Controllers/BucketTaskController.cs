using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Api.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.BucketTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BucketTaskController : ControllerBase
{
    private readonly IBucketTaskService _bucketTaskService;
    private readonly IValidator<BucketTaskDto> _bucketTaskDTOValidator;
    private readonly IMapper _mapper;

    public BucketTaskController(IBucketTaskService bucketTaskService, IValidator<BucketTaskDto> bucketTaskDTOValidator, IMapper mapper)
    {
        _bucketTaskService = bucketTaskService;
        _bucketTaskDTOValidator = bucketTaskDTOValidator;
        _mapper = mapper;
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
    public IActionResult Post([FromBody] BucketTaskDto bucketTaskDTO)
    {
        _bucketTaskDTOValidator.ValidateAndThrow(bucketTaskDTO);

        var bucketTaskId = _bucketTaskService.InsertBucketTask(bucketTaskDTO);

        return Ok(bucketTaskDTO);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BucketTaskDto bucketTaskDTO)
    {
        _bucketTaskDTOValidator.ValidateAndThrow(bucketTaskDTO);

        _bucketTaskService.UpdateBucketTask(id, bucketTaskDTO);

        return Ok(bucketTaskDTO);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var bucketTaskToDelete = _bucketTaskService.GetBucketTask(id);

        var mappedBucketTask = _mapper.Map<BucketTaskDto>(bucketTaskToDelete);

        _bucketTaskDTOValidator.ValidateAndThrow(mappedBucketTask);

        _bucketTaskService.DeleteBucketTask(id);

        return Ok(bucketTaskToDelete);
    }
}
