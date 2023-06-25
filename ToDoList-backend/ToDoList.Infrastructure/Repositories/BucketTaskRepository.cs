using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

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

    public void DeleteBucketTask(int bucketTaskId)
    {
        var bucketTaskToDelete = _toDoListDbContext.BucketTasks!.First(a => a.Id == bucketTaskId);
        _toDoListDbContext.BucketTasks!.Remove(bucketTaskToDelete);
        _toDoListDbContext.SaveChanges();
    }

    public int InsertBucketTask(BucketTask bucketTask)
    {
        _toDoListDbContext.BucketTasks!.Add(bucketTask);
        _toDoListDbContext.SaveChanges();

        return bucketTask.Id;
    }

    public void UpdateBucketTask(int id, BucketTask bucketTask)
    {
        var bucketTaskToUpdate = _toDoListDbContext.BucketTasks!.First(a => a.Id == id);

        bucketTaskToUpdate.Name = bucketTask.Name;
        bucketTaskToUpdate.Description = bucketTask.Description;
        bucketTaskToUpdate.TaskState = bucketTask.TaskState;
        bucketTaskToUpdate.TaskPriority = bucketTask.TaskPriority;

        _toDoListDbContext.BucketTasks!.Update(bucketTaskToUpdate);
        _toDoListDbContext.SaveChanges();
    }
}