using AutoMapper;
using System.Collections.Generic;
using ToDoList.Api.Bucket.Models;
using ToDoList.Api.Interfaces;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Bucket.Services
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository bucketRepository;
        private readonly ToDoListDbContext toDoListDbContext;
        private readonly IMapper mapper;

        public BucketService(IBucketRepository bucketRepository, ToDoListDbContext toDoListDbContext, IMapper mapper)
        {
            this.bucketRepository = bucketRepository;
            this.toDoListDbContext = toDoListDbContext;
            this.mapper = mapper;
        }

        public List<Domain.Models.Bucket> GetAllBuckets()
        {
            return bucketRepository.GetAllBuckets();
        }

        public Domain.Models.Bucket GetBucket(int bucketId)
        {
            return bucketRepository.GetBucket(bucketId);
        }

        public void DeleteBucket(int bucketId)
        {
            throw new System.NotImplementedException();
        }

        public int InsertBucket(BucketDTO bucketDTO)
        {
            if (toDoListDbContext.Buckets is not null)
            {
                var mappedBucket = mapper.Map<Domain.Models.Bucket>(bucketDTO);

                toDoListDbContext.Buckets.Add(mappedBucket);
                toDoListDbContext.SaveChanges();
            }

            return bucketDTO.Id;
        }

        public void UpdateBucket(Domain.Models.Bucket bucket)
        {
            throw new System.NotImplementedException();
        }
    }
}
