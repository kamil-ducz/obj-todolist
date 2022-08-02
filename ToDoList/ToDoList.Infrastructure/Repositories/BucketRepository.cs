using ToDoList.Api;
using ToDoList.Domain.Models;
using ToDoList.Infrastructure.Interfaces;

namespace ToDoList.Infrastructure.Repositories
{
    public class BucketRepository : IBucketRepository
    {
        public List<Bucket> GetAllBuckets()
        {
            return Database.GetAllBuckets();
        }

        public Bucket GetBucket(int bucketId)
        {
            return Database.GetBucket(bucketId);
        }

        public void DeleteBucket(int bucketId)
        {
            throw new NotImplementedException();
        }

        public int InsertBucket(int bucketId)
        {
            throw new NotImplementedException();
        }

        public void UpdateBucket(int bucketId)
        {
            throw new NotImplementedException();
        }
    }
}
