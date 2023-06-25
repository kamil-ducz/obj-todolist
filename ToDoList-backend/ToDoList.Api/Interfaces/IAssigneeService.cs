using System.Collections.Generic;
using ToDoList.Api.Asignee.Models;

namespace ToDoList.Api.Interfaces;

public interface IAssigneeService
{
    List<AssigneeDto> GetAllAssignees();
    AssigneeDto GetAssignee(int assigneeId);
    int InsertAssignee(AssigneeInsertDto assigneeId);
    void DeleteAssignee(int assigneeId);
    void UpdateAssignee(int id, AssigneeInsertDto assignee);
}
