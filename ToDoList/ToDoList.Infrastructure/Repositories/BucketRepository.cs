using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Repositories
{
    public class BucketRepository : IBucketRepository
    {
        private readonly ToDoListDbContext _toDoListDbContext;

        public BucketRepository(ToDoListDbContext toDoListDbContext)
        {
            this._toDoListDbContext = toDoListDbContext;
        }

        public List<Bucket> GetAllBuckets()
        {
            if (_toDoListDbContext.Buckets is not null)
            {
                var buckets = _toDoListDbContext.Buckets.ToList();

                return buckets;
            }

            throw new NotImplementedException();
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
