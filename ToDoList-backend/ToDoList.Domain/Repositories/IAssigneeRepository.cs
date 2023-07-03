using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Repositories;

public interface IAssigneeRepository
{
    IReadOnlyList<Assignee> GetAllAssignees();
    Assignee GetAssignee(int assigneeId);
    void InsertAssignee(Assignee assignee);
    void DeleteAssignee(Assignee assignee);
    void UpdateAssignee(Assignee assignee);
}
