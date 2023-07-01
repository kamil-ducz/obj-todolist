using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Infrastructure.Repositories;

public class AssigneeRepository : IAssigneeRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public AssigneeRepository(ToDoListDbContext toDoListDbContext)
    {
        this._toDoListDbContext = toDoListDbContext;
    }

    public IReadOnlyList<Assignees> GetAllAssignees()
    {
        return _toDoListDbContext.Assignees!.ToList();
    }

    public Assignees GetAssignee(int assigneeId)
    {
        return _toDoListDbContext.Assignees!.First(a => a.Id == assigneeId);
    }

    public void DeleteAssignee(int assigneeId)
    {
        var assigneeToDelete = _toDoListDbContext.Assignees!.First(a => a.Id == assigneeId);
        _toDoListDbContext.Assignees!.Remove(assigneeToDelete);
        _toDoListDbContext.SaveChanges();
    }

    public void InsertAssignee(Assignees assignee)
    {
        _toDoListDbContext.Assignees!.Add(assignee);
        _toDoListDbContext.SaveChanges();
    }

    public void UpdateAssignee(Assignees assigneeToUpdate)
    {
        _toDoListDbContext.Assignees!.Update(assigneeToUpdate);
        _toDoListDbContext.SaveChanges();
    }
}