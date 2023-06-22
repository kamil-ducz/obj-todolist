using AutoMapper;
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
        private readonly IMapper _mapper;

        public BucketController(IBucketService bucketService, IValidator<BucketDTO> bucketDTOValidator, IMapper mapper)
        {
            this.bucketService = bucketService;
            this._bucketDTOValidator = bucketDTOValidator;
            this._mapper = mapper;
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

            var bucketId = bucketService.InsertBucket(bucketDTO);

            return Ok($"Bucket with id={ bucketId } inserted into database.");

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BucketDTO bucketDTO)
        {
            _bucketDTOValidator.ValidateAndThrow(bucketDTO);

            bucketService.UpdateBucket(id, bucketDTO);

            return Ok(bucketDTO);


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bucketToDelete = bucketService.GetBucket(id);

            var mappedBucket = _mapper.Map<BucketDTO>(bucketToDelete);

            _bucketDTOValidator.ValidateAndThrow(mappedBucket);

            bucketService.DeleteBucket(id);

            return Ok(bucketToDelete);
        }
    }
}
