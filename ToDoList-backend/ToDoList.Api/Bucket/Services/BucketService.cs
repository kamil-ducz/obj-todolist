using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.Bucket.Models;
using ToDoList.Api.Interfaces;
using ToDoList.Domain.Interfaces;
using ToDoList.Infrastructure.Repositories;

namespace ToDoList.Api.Bucket.Services
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository bucketRepository;
        private readonly IBucketTaskRepository bucketTaskRepository;
        private readonly IMapper mapper;

        public BucketService(IBucketRepository bucketRepository, IBucketTaskRepository bucketTaskRepository, IMapper mapper)
        {
            this.bucketRepository = bucketRepository;
            this.bucketTaskRepository = bucketTaskRepository;
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
            bucketRepository.DeleteBucket(bucketId);        
        }

        public int InsertBucket(BucketDTO bucketDTO)
        {
            var mappedBucket = mapper.Map<Domain.Models.Bucket>(bucketDTO);

            return bucketRepository.InsertBucket(mappedBucket);
        }

        public void UpdateBucket(int id, BucketDTO bucketDTO)
        {
            var mappedBucket = mapper.Map<Domain.Models.Bucket>(bucketDTO);

            bucketRepository.UpdateBucket(id, mappedBucket);
        }

        public IEnumerable<Domain.Models.BucketTask> GetAllBucketsTasks(int bucketId)
        {
            var bucketTasks = bucketTaskRepository.GetAllBucketTasks().Where(b => b.BucketId == bucketId);
            return bucketTasks;
        }
    }
}
