using ToDoList.Api;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Infrastructure.Repositories;

public class AssigneeRepository : IAssigneeRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public AssigneeRepository(ToDoListDbContext toDoListDbContext)
    {
        _toDoListDbContext = toDoListDbContext;
    }

    public IReadOnlyList<Assignee> GetAllAssignees()
    {
        return _toDoListDbContext.Assignees.ToList();
    }

    public Assignee GetAssignee(int assigneeId)
    {
        return _toDoListDbContext.Assignees.First(a => a.Id == assigneeId);
    }

    public void DeleteAssignee(Assignee assignee)
    {
        _toDoListDbContext.Assignees.Remove(assignee);
        _toDoListDbContext.SaveChanges();
    }

    public void InsertAssignee(Assignee assignee)
    {
        _toDoListDbContext.Assignees.Add(assignee);
        _toDoListDbContext.SaveChanges();
    }

    public void UpdateAssignee(Assignee assignee)
    {
        _toDoListDbContext.Assignees.Update(assignee);
        _toDoListDbContext.SaveChanges();
    }
}