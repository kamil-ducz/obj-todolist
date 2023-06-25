using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Repositories;

public class AssigneeRepository : IAssigneeRepository
{
    private readonly ToDoListDbContext _toDoListDbContext;

    public AssigneeRepository(ToDoListDbContext toDoListDbContext)
    {
        this._toDoListDbContext = toDoListDbContext;
    }

    public IReadOnlyList<Assignee> GetAllAssignees()
    {
        return _toDoListDbContext.Assignees!.ToList();
    }

    public Assignee GetAssignee(int assigneeId)
    {
        return _toDoListDbContext.Assignees!.First(a => a.Id == assigneeId);
    }

    public void DeleteAssignee(int assigneeId)
    {
        var assigneeToDelete = _toDoListDbContext.Assignees!.First(a => a.Id == assigneeId);
        _toDoListDbContext.Assignees!.Remove(assigneeToDelete);
        _toDoListDbContext.SaveChanges();
    }

    public int InsertAssignee(Assignee assignee)
    {
        _toDoListDbContext.Assignees!.Add(assignee);
        _toDoListDbContext.SaveChanges();

        return assignee.Id;
    }

    public void UpdateAssignee(int id, Assignee assignee)
    {
        var assigneeToUpdate = _toDoListDbContext.Assignees!.First(a => a.Id == id);

        assigneeToUpdate.Name = assignee.Name;
        assigneeToUpdate.BucketTasks = assignee.BucketTasks;

        _toDoListDbContext.Assignees!.Update(assigneeToUpdate);
        _toDoListDbContext.SaveChanges();
    }
}
