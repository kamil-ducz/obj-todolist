using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces
{
    public interface IAssigneeRepository
    {
        List<Assignee> GetAllAssignees();
        Assignee GetAssignee(int assigneeId);
        int InsertAssignee(Assignee assignee);
        void DeleteAssignee(Assignee assignee);
        void UpdateAssignee(Assignee assignee);
    }
}
