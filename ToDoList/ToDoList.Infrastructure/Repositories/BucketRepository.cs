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
            if (_toDoListDbContext.Buckets is not null)
            {
                return _toDoListDbContext.Buckets.First(a => a.Id == bucketId);
            }

            throw new NotImplementedException();
        }

        public void DeleteBucket(int bucketId)
        {
            if (_toDoListDbContext.Buckets is not null)
            {
                var bucketToDelete = _toDoListDbContext.Buckets.First(a => a.Id == bucketId);
                _toDoListDbContext.Buckets.Remove(bucketToDelete);
                _toDoListDbContext.SaveChanges();

            }

            else
            {
                throw new NotImplementedException();
            }

            // TODO what if we want to delete connected bucket tasks?
        }

        public int InsertBucket(Bucket bucket)
        {
            if (_toDoListDbContext.Buckets is not null)
            {
                _toDoListDbContext.Buckets.Add(bucket);
                _toDoListDbContext.SaveChanges();

                return bucket.Id;
            }

            throw new NotImplementedException();
        }

        public void UpdateBucket(Bucket bucket)
        {
            throw new NotImplementedException();
        }
    }
}
