using AutoMapper;
using System.Collections.Generic;
using ToDoList.Api.Asignee.Models;
using ToDoList.Api.Interfaces;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Assignee.Services;

public class AssigneeService : IAssigneeService
{
    private readonly IAssigneeRepository assigneeRepository;
    private readonly IMapper mapper;

    public AssigneeService(IAssigneeRepository assigneeRepository, IMapper mapper)
    {
        this.assigneeRepository = assigneeRepository;
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
        assigneeRepository.DeleteAssignee(assigneeId);
    }

    public int InsertAssignee(AssigneeDTO assigneeDTO)
    {
        var mappedAssignee = mapper.Map<Domain.Models.Assignee>(assigneeDTO);

        return assigneeRepository.InsertAssignee(mappedAssignee); ;
    }

    public void UpdateAssignee(int id, AssigneeDTO assigneeDTO)
    {
        var mappedAssignee = mapper.Map<Domain.Models.Assignee>(assigneeDTO);

        assigneeRepository.UpdateAssignee(id, mappedAssignee);
    }
}
