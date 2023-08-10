using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;

public interface IUserRepository
{
    IReadOnlyList<User> GetAllUsers();
    User GetUser(int userId);
    void InsertUser(User user);
    void DeleteUser(User user);
    void UpdateUser(User user);
}
