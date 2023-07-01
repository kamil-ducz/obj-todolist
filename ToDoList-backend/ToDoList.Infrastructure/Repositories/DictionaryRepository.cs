using ToDoList.Domain.Repositories;

namespace ToDoList.Infrastructure.Repositories;

public class DictionaryRepository : IDictionaryRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public DictionaryRepository(ToDoListDbContext toDoListDbContext)
    {
        _toDoListDbContext = toDoListDbContext;
    }

    public IReadOnlyList<T> GetAll<T>() where T : class
    {
        return _toDoListDbContext.Set<T>().ToList();
    }

    public T GetById<T>(int id) where T : class
    {
        // TODO: Introduce base Entity class with Id property
        throw new NotImplementedException();
    }
}