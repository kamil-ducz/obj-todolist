using ToDoList.Api;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public UserRepository(ToDoListDbContext toDoListDbContext)
    {
        _toDoListDbContext = toDoListDbContext;
    }

    public IReadOnlyList<User> GetAllUsers()
    {
        return _toDoListDbContext.Users.ToList();
    }

    public User GetUser(int userId)
    {
        return _toDoListDbContext.Users.First(a => a.Id == userId);
    }

    public void DeleteUser(User user)
    {
        _toDoListDbContext.Users.Remove(user);
        _toDoListDbContext.SaveChanges();
    }

    public void InsertUser(User user)
    {
        _toDoListDbContext.Users.Add(user);
        _toDoListDbContext.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        _toDoListDbContext.Users.Update(user);
        _toDoListDbContext.SaveChanges();
    }
}