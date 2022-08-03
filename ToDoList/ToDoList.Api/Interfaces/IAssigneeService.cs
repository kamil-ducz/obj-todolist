using System.Collections.Generic;

namespace ToDoList.Api.Interfaces
{
    public interface IAssigneeService
    {
        List<Domain.Models.Assignee> GetAllAssignees();
        Domain.Models.Assignee GetAssignee(int assigneeId);
        int InsertAssignee(Domain.Models.Assignee assigneeId);
        void DeleteAssignee(int assigneeId);
        void UpdateAssignee(Domain.Models.Assignee assignee);
    }
}
