using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;

public interface IUserRepository
{
    IReadOnlyList<User> GetAllUsers();
    User GetUser(int assigneeId);
    void InsertUser(User assignee);
    void DeleteUser(User assignee);
    void UpdateUser(User assignee);
}
