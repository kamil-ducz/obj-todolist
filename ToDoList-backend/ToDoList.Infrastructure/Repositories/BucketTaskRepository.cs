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
        return _toDoListDbContext.BucketTasks!.ToList();
    }

    public BucketTask GetBucketTask(int bucketTaskId)
    {
        return _toDoListDbContext.BucketTasks!.First(a => a.Id == bucketTaskId);
    }

    public void DeleteBucketTask(BucketTask bucketTaskToDelete)
    {
        _toDoListDbContext.BucketTasks!.Remove(bucketTaskToDelete);
        _toDoListDbContext.SaveChanges();
    }

    public void InsertBucketTask(BucketTask bucketTask)
    {
        _toDoListDbContext.BucketTasks!.Add(bucketTask);
        _toDoListDbContext.SaveChanges();
    }

    public void UpdateBucketTask(BucketTask bucketTaskToUpdate)
    {
        _toDoListDbContext.BucketTasks!.Update(bucketTaskToUpdate);
        _toDoListDbContext.SaveChanges();
    }
}