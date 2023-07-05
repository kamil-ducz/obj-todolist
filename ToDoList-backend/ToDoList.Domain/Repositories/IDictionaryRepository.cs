using System.Collections.Generic;

namespace ToDoList.Domain.Repositories;
public interface IDictionaryRepository
{
    IReadOnlyCollection<T> GetAll<T>() where T : class;
}
