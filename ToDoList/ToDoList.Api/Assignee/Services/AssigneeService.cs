using System.Collections.Generic;
using ToDoList.Api.Interfaces;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Assignee.Services
{
    public class AssigneeService : IAssigneeService
    {
        private readonly IAssigneeRepository assigneeRepository;

        public AssigneeService(IAssigneeRepository assigneeRepository)
        {
            this.assigneeRepository = assigneeRepository;
        }

        public List<Domain.Models.Assignee> GetAllAssignees()
        {
            return assigneeRepository.GetAllAssignees();
        }

        public Domain.Models.Assignee GetAssignee(int assigneeId)
        {
            return assigneeRepository.GetAssignee(assigneeId);
        }

        public void DeleteAssignee(int assigneeId)
        {
            throw new System.NotImplementedException();
        }

        public int InsertAssignee(int assigneeId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateAssignee(int assigneeId)
        {
            throw new System.NotImplementedException();
        }
    }
}
