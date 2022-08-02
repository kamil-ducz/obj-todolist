using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces
{
    public interface IAssigneeRepository
    {
        List<Assignee> GetAllAssignees();
        Assignee GetAssignee(int assigneeId);
        int InsertAssignee(int assigneeId);
        void DeleteAssignee(int assigneeId);
        void UpdateAssignee(int assigneeId);
    }
}
