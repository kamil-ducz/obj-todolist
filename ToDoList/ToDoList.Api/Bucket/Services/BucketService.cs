using System.Collections.Generic;
using ToDoList.Api.Interfaces;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Bucket.Services
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository bucketRepository;

        public BucketService(IBucketRepository bucketRepository)
        {
            this.bucketRepository = bucketRepository;
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

        public int InsertBucket(Domain.Models.Bucket bucket)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBucket(Domain.Models.Bucket bucket)
        {
            throw new System.NotImplementedException();
        }
    }
}
