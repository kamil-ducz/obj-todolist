using System.Collections.Generic;
using ToDoList.Api.Asignee.Models;

namespace ToDoList.Api.Interfaces;

public interface IAssigneeService
{
    IReadOnlyCollection<AssigneeDto> GetAllAssignees();
    AssigneeDto GetAssignee(int assigneeId);
    int InsertAssignee(AssigneeInsertDto assignee);
    void DeleteAssignee(int assigneeId);
    void UpdateAssignee(AssigneeInsertDto assignee, int assigneeId);
}
