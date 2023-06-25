using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces;

public interface IAssigneeRepository
{
    IReadOnlyList<Assignee> GetAllAssignees();
    Assignee GetAssignee(int assigneeId);
    int InsertAssignee(Assignee assignee);
    void DeleteAssignee(int assigneeId);
    void UpdateAssignee(int id, Assignee assignee);
}
