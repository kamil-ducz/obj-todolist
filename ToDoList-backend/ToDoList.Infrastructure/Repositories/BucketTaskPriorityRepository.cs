using ToDoList.Api;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Infrastructure.Repositories;
public class BucketTaskPriorityRepository : IBucketTaskPriorityRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public BucketTaskPriorityRepository(ToDoListDbContext toDoListDbContext)
    {
        _toDoListDbContext = toDoListDbContext;
    }
    public IReadOnlyCollection<BucketTaskPriority> GetAllBucketTaskPriorities()
    {
        return _toDoListDbContext.BucketTaskPriority.ToList();
    }
}
