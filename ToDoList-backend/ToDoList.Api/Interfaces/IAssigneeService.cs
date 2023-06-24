using System.Collections.Generic;
using ToDoList.Api.Asignee.Models;

namespace ToDoList.Api.Interfaces;

public interface IAssigneeService
{
    List<Domain.Models.Assignee> GetAllAssignees();
    Domain.Models.Assignee GetAssignee(int assigneeId);
    int InsertAssignee(AssigneeDTO assigneeId);
    void DeleteAssignee(int assigneeId);
    void UpdateAssignee(int id, AssigneeDTO assignee);
}
