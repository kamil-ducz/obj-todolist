using ToDoList.Api;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Infrastructure.Repositories;

public class BucketTaskRepository : IBucketTaskRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public BucketTaskRepository(ToDoListDbContext toDoListDbContext)
    {
        this._toDoListDbContext = toDoListDbContext;
    }

    public IReadOnlyList<BucketTask> GetAllBucketTasks()
    {
        return _toDoListDbContext.BucketTask!.ToList();
    }

    public BucketTask GetBucketTask(int bucketTaskId)
    {
        return _toDoListDbContext.BucketTask!.First(a => a.Id == bucketTaskId);
    }

    public void DeleteBucketTask(BucketTask bucketTaskToDelete)
    {
        _toDoListDbContext.BucketTask!.Remove(bucketTaskToDelete);
        _toDoListDbContext.SaveChanges();
    }

    public void InsertBucketTask(BucketTask bucketTask)
    {
        _toDoListDbContext.BucketTask!.Add(bucketTask);
        _toDoListDbContext.SaveChanges();
    }

    public void UpdateBucketTask(BucketTask bucketTaskToUpdate)
    {
        _toDoListDbContext.BucketTask!.Update(bucketTaskToUpdate);
        _toDoListDbContext.SaveChanges();
    }
}