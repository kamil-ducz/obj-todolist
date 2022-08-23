using AutoMapper;
using System.Collections.Generic;
using ToDoList.Api.Asignee.Models;
using ToDoList.Api.Interfaces;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Assignee.Services
{
    public class AssigneeService : IAssigneeService
    {
        private readonly IAssigneeRepository assigneeRepository;
        private readonly ToDoListDbContext toDoListDbContext;
        private readonly IMapper mapper;

        public AssigneeService(IAssigneeRepository assigneeRepository, ToDoListDbContext toDoListDbContext, IMapper mapper)
        {
            this.assigneeRepository = assigneeRepository;
            this.toDoListDbContext = toDoListDbContext;
            this.mapper = mapper;
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

        public int InsertAssignee(AssigneeDTO assigneeDTO)
        {
            if (toDoListDbContext.Assignees is not null)
            {
                var mappedAssignee = mapper.Map<Domain.Models.Assignee>(assigneeDTO);

                toDoListDbContext.Assignees.Add(mappedAssignee);
                toDoListDbContext.SaveChanges();
            }

            return assigneeDTO.Id;
        }

        public void UpdateAssignee(Domain.Models.Assignee assignee)
        {
            throw new System.NotImplementedException();
        }
    }
}
