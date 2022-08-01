using System.Collections.Generic;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Assignee.Services
{
    public class AssigneeService
    {
        public IAssignee AssigneeRepository { get; }

        public AssigneeService(IAssignee assigneeRepository)
        {
            AssigneeRepository = assigneeRepository;
        }

        public List<Domain.Models.Assignee> GetAssignees()
        {
            return AssigneeRepository.GetAllAssignees();
        }

        public Domain.Models.Assignee GetAssignee(int id)
        {
            return AssigneeRepository.GetAssignee(id);
        }

    }
}
