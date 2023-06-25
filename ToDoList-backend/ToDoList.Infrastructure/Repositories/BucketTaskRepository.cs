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
        if (_toDoListDbContext.BucketTasks is not null)
        {
            return _toDoListDbContext.BucketTasks.ToList();
        }

        throw new NotImplementedException();
    }

    public BucketTask GetBucketTask(int bucketTaskId)
    {
        if (_toDoListDbContext.BucketTasks is not null)
        {
            return _toDoListDbContext.BucketTasks.First(a => a.Id == bucketTaskId);
        }

        throw new NotImplementedException();
    }

    public void DeleteBucketTask(int bucketTaskId)
    {
        if (_toDoListDbContext.BucketTasks is not null)
        {
            var bucketTaskToDelete = _toDoListDbContext.BucketTasks.First(a => a.Id == bucketTaskId);
            _toDoListDbContext.BucketTasks.Remove(bucketTaskToDelete);
            _toDoListDbContext.SaveChanges();
        }

        else
        {
            throw new NotImplementedException();
        }
    }

    public int InsertBucketTask(BucketTask bucketTask)
    {
        if (_toDoListDbContext.BucketTasks is not null)
        {
            _toDoListDbContext.BucketTasks.Add(bucketTask);
            _toDoListDbContext.SaveChanges();

            return bucketTask.Id;
        }

        throw new NotImplementedException();
    }

    public void UpdateBucketTask(int id, BucketTask bucketTask)
    {
        if (_toDoListDbContext.BucketTasks is not null)
        {
            var bucketTaskToUpdate = _toDoListDbContext.BucketTasks.First(a => a.Id == id);

            bucketTaskToUpdate.Name = bucketTask.Name;
            bucketTaskToUpdate.Description = bucketTask.Description;
            bucketTaskToUpdate.TaskState = bucketTask.TaskState;
            bucketTaskToUpdate.TaskPriority = bucketTask.TaskPriority;

            _toDoListDbContext.BucketTasks.Update(bucketTaskToUpdate);
            _toDoListDbContext.SaveChanges();
        }

        else
        {
            throw new NotImplementedException();
        }
    }
}
