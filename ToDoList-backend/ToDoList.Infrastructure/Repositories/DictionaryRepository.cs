using ToDoList.Api;
using ToDoList.Domain.Repositories;

namespace ToDoList.Infrastructure.Repositories;
public class DictionaryRepository : IDictionaryRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public DictionaryRepository(ToDoListDbContext toDoListDbContext)
    {
        _toDoListDbContext = toDoListDbContext;
    }
    public IReadOnlyCollection<T> GetAll<T>() where T : class
    {
        return _toDoListDbContext.Set<T>().ToList();
    }
}
