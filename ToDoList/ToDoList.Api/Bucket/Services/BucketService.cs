using System.Collections.Generic;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Bucket.Services
{
    public class BucketService
    {
        public IBucket BucketRepository { get; }

        public BucketService(IBucket bucketRepository)
        {
            BucketRepository = bucketRepository;
        }

        public List<Domain.Models.Bucket> GetBuckets()
        {
            return BucketRepository.GetAllBuckets();
        }

        public Domain.Models.Bucket GetBucket(int id)
        {
            return BucketRepository.GetBucket(id);
        }

    }
}
