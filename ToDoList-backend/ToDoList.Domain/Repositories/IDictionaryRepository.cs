using System.Collections.Generic;

namespace ToDoList.Domain.Repositories;

public interface IDictionaryRepository
{
    // TODO: Add base Entity class
    IReadOnlyList<T> GetAll<T>() where T : class;
    T GetById<T>(int id) where T : class;
}