using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.BucketTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketTaskController : ControllerBase
    {
        private readonly IBucketTaskService bucketTaskService;

        public BucketTaskController(IBucketTaskService bucketTaskService)
        {
            this.bucketTaskService = bucketTaskService;
        }

        // GET: api/<BucketTaskController>
        [HttpGet]
        public IEnumerable<Domain.Models.BucketTask> Get()
        {
            return bucketTaskService.GetBucketTasks();
        }

        // GET api/<BucketTaskController>/5
        [HttpGet("{id}")]
        public Domain.Models.BucketTask Get(int id)
        {
            return bucketTaskService.GetBucketTask(id);
        }

        // POST api/<BucketTaskController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
