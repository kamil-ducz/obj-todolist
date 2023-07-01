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

    public IReadOnlyList<BucketTasks> GetAllBucketTasks()
    {
        return _toDoListDbContext.BucketTasks!.ToList();
    }

    public BucketTasks GetBucketTask(int bucketTaskId)
    {
        return _toDoListDbContext.BucketTasks!.First(a => a.Id == bucketTaskId);
    }

    public void DeleteBucketTask(BucketTasks bucketTaskToDelete)
    {
        _toDoListDbContext.BucketTasks!.Remove(bucketTaskToDelete);
        _toDoListDbContext.SaveChanges();
    }

    public void InsertBucketTask(BucketTasks bucketTask)
    {
        _toDoListDbContext.BucketTasks!.Add(bucketTask);
        _toDoListDbContext.SaveChanges();
    }

    public void UpdateBucketTask(BucketTasks bucketTaskToUpdate)
    {
        _toDoListDbContext.BucketTasks!.Update(bucketTaskToUpdate);
        _toDoListDbContext.SaveChanges();
    }
}