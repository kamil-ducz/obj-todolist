using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Validation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.BucketTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketTaskController : ControllerBase
    {
        private readonly IBucketTaskService bucketTaskService;
        private readonly BucketTaskDTOValidator _bucketTaskDTOValidator;

        public BucketTaskController(IBucketTaskService bucketTaskService, BucketTaskDTOValidator bucketTaskDTOValidator)
        {
            this.bucketTaskService = bucketTaskService;
            this._bucketTaskDTOValidator = bucketTaskDTOValidator;
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

            return Ok();
        }

        // PUT api/<BucketTaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BucketTaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
