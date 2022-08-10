using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Api.Bucket.Models;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Validation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.Bucket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketController : ControllerBase
    {
        private readonly IBucketService bucketService;

        BucketDTOValidator bucketDTOValidator = new BucketDTOValidator();

        public BucketController(IBucketService bucketService)
        {
            this.bucketService = bucketService;
        }

        // GET: api/<BucketController>
        [HttpGet]
        public IEnumerable<Domain.Models.Bucket> Get()
        {
            return bucketService.GetAllBuckets();
        }

        // GET api/<BucketController>/5
        [HttpGet("{id}")]
        public Domain.Models.Bucket Get(int id)
        {
            return bucketService.GetBucket(id);
        }

        // POST api/<BucketController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BucketDTO bucketDTO)
        {
            var validationResult = bucketDTOValidator.Validate(bucketDTO);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            return Ok();
        }

        // PUT api/<BucketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Domain.Models.Bucket value)
        {
        }

        // DELETE api/<BucketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
