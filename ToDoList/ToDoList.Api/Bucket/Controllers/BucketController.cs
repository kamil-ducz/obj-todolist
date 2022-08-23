using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Bucket.Models;
using ToDoList.Api.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.Bucket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketController : ControllerBase
    {
        private readonly IBucketService bucketService;
        private readonly IValidator<BucketDTO> _bucketDTOValidator;

        public BucketController(IBucketService bucketService, IValidator<BucketDTO> bucketDTOValidator)
        {
            this.bucketService = bucketService;
            this._bucketDTOValidator = bucketDTOValidator;
        }

        [HttpGet]
        public IEnumerable<Domain.Models.Bucket> Get()
        {
            return bucketService.GetAllBuckets();
        }

        [HttpGet("{id}")]
        public Domain.Models.Bucket Get(int id)
        {
            return bucketService.GetBucket(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BucketDTO bucketDTO)
        {
            _bucketDTOValidator.ValidateAndThrow(bucketDTO);

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
