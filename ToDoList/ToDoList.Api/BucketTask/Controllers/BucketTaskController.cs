using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Api.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.BucketTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketTaskController : ControllerBase
    {
        private readonly IBucketTaskService bucketTaskService;
        private readonly IValidator<BucketTaskDTO> _bucketTaskDTOValidator;
        private readonly IMapper _mapper;

        public BucketTaskController(IBucketTaskService bucketTaskService, IValidator<BucketTaskDTO> bucketTaskDTOValidator, IMapper mapper)
        {
            this.bucketTaskService = bucketTaskService;
            this._bucketTaskDTOValidator = bucketTaskDTOValidator;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Domain.Models.BucketTask> Get()
        {
            return bucketTaskService.GetBucketTasks();
        }

        [HttpGet("{id}")]
        public Domain.Models.BucketTask Get(int id)
        {
            return bucketTaskService.GetBucketTask(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BucketTaskDTO bucketTaskDTO)
        {
            _bucketTaskDTOValidator.ValidateAndThrow(bucketTaskDTO);

            var bucketTaskId = bucketTaskService.InsertBucketTask(bucketTaskDTO);

            return Ok($"Bucket task with id={ bucketTaskId } inserted into database.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BucketTaskDTO bucketTaskDTO)
        {
            _bucketTaskDTOValidator.ValidateAndThrow(bucketTaskDTO);

            bucketTaskService.UpdateBucketTask(id, bucketTaskDTO);

            return Ok($"Bucket task with id={ id } has been updated.");


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bucketTaskToDelete = bucketTaskService.GetBucketTask(id);

            var mappedBucketTask = _mapper.Map<BucketTaskDTO>(bucketTaskToDelete);

            _bucketTaskDTOValidator.ValidateAndThrow(mappedBucketTask);

            bucketTaskService.DeleteBucketTask(id);

            return Ok($"Bucket task with id={ id } deleted.");
        }
    }
}
