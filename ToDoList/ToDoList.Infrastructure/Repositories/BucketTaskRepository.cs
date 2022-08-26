using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Repositories
{
    public class BucketTaskRepository : IBucketTaskRepository
    {
        private readonly ToDoListDbContext _toDoListDbContext;

        public BucketTaskRepository(ToDoListDbContext toDoListDbContext)
        {
            this._toDoListDbContext = toDoListDbContext;
        }

        public List<BucketTask> GetAllBucketTasks()
        {
            if (_toDoListDbContext.BucketTasks is not null)
            {
                return _toDoListDbContext.BucketTasks.ToList();
            }

            throw new NotImplementedException();
        }

        public BucketTask GetBucketTask(int taskId)
        {
            return Database.GetBucketTask(taskId);
        }

        public void DeleteBucketTask(int taskId)
        {
            throw new NotImplementedException();
        }

        public int InsertBucketTask(BucketTask task)
        {
            throw new NotImplementedException();
        }

        public void UpdateBucketTask(BucketTask task)
        {
            throw new NotImplementedException();
        }
    }
}
