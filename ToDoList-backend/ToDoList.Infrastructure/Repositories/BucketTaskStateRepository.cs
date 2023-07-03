using ToDoList.Api;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Infrastructure.Repositories;
public class BucketTaskStateRepository : IBucketTaskStateRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public BucketTaskStateRepository(ToDoListDbContext toDoListDbContext)
    {
        _toDoListDbContext = toDoListDbContext;
    }
    public IReadOnlyCollection<BucketTaskState> GetAllBucketTaskStates()
    {
        return _toDoListDbContext.BucketTaskStates.ToList();
    }
}
