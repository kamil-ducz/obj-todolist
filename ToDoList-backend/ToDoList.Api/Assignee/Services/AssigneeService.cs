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

    public List<AssigneeDto> GetAllAssignees()
    {
        return _mapper.Map<List<AssigneeDto>>(_assigneeRepository.GetAllAssignees());
    }

    public AssigneeDto GetAssignee(int assigneeId)
    {
        return _mapper.Map<AssigneeDto>(_assigneeRepository.GetAssignee(assigneeId));
    }

    public void DeleteAssignee(int assigneeId)
    {
        _assigneeRepository.DeleteAssignee(assigneeId);
    }

    public int InsertAssignee(AssigneeDto assigneeDTO)
    {
        var mappedAssignee = _mapper.Map<Domain.Models.Assignee>(assigneeDTO);

        return _assigneeRepository.InsertAssignee(mappedAssignee); ;
    }

    public void UpdateAssignee(int id, AssigneeDto assigneeDTO)
    {
        var mappedAssignee = _mapper.Map<Domain.Models.Assignee>(assigneeDTO);

        _assigneeRepository.UpdateAssignee(id, mappedAssignee);
    }
}
