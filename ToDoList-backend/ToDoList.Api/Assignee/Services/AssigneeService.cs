using AutoMapper;
using System.Collections.Generic;
using ToDoList.Api.Asignee.Models;
using ToDoList.Api.Interfaces;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Assignee.Services;

public class AssigneeService : IAssigneeService
{
    private readonly IAssigneeRepository _assigneeRepository;
    private readonly IMapper _mapper;

    public AssigneeService(IAssigneeRepository assigneeRepository, IMapper mapper)
    {
        _assigneeRepository = assigneeRepository;
        _mapper = mapper;
    }

    public List<Domain.Models.Assignee> GetAllAssignees()
    {
        return _assigneeRepository.GetAllAssignees();
    }

    public Domain.Models.Assignee GetAssignee(int assigneeId)
    {
        return _assigneeRepository.GetAssignee(assigneeId);
    }

    public void DeleteAssignee(int assigneeId)
    {
        _assigneeRepository.DeleteAssignee(assigneeId);
    }

    public int InsertAssignee(AssigneeDTO assigneeDTO)
    {
        var mappedAssignee = _mapper.Map<Domain.Models.Assignee>(assigneeDTO);

        return _assigneeRepository.InsertAssignee(mappedAssignee); ;
    }

    public void UpdateAssignee(int id, AssigneeDTO assigneeDTO)
    {
        var mappedAssignee = _mapper.Map<Domain.Models.Assignee>(assigneeDTO);

        _assigneeRepository.UpdateAssignee(id, mappedAssignee);
    }
}
