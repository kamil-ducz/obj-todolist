using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;

public interface IAssigneeRepository
{
    IReadOnlyList<Assignees> GetAllAssignees();
    Assignees GetAssignee(int assigneeId);
    void InsertAssignee(Assignees assignee);
    void DeleteAssignee(int assigneeId);
    void UpdateAssignee(Assignees assignee);
}
