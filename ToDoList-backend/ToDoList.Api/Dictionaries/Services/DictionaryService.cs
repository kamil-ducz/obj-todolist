using System.Collections.Generic;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Dictionaries.Services;

public interface IDictionaryService
{
    IReadOnlyCollection<T> GetAll<T>() where T : class;
}

public class DictionaryService : IDictionaryService
{
    private readonly IDictionaryRepository _dictionaryRepository;

    public DictionaryService(IDictionaryRepository dictionaryRepository)
    {
        _dictionaryRepository = dictionaryRepository;
    }
    public IReadOnlyCollection<T> GetAll<T>() where T : class
    {
        return _dictionaryRepository.GetAll<T>();
    }
}
