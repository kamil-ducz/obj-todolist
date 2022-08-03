using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

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

        public int InsertBucket(Bucket bucket)
        {
            throw new NotImplementedException();
        }

        public void UpdateBucket(Bucket bucket)
        {
            throw new NotImplementedException();
        }
    }
}
