using AutoMapper;
using System.Collections.Generic;
using ToDoList.Api.Asignee.Models;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Assignee.Services;

public interface IAssigneeService
{
    IReadOnlyCollection<AssigneeDto> GetAllAssignees();
    AssigneeDto GetAssignee(int assigneeId);
    int InsertAssignee(AssigneeInsertDto assignee);
    void DeleteAssignee(int assigneeId);
    void UpdateAssignee(AssigneeInsertDto assignee, int assigneeId);
}

public class AssigneeService : IAssigneeService
{
    private readonly IAssigneeRepository _assigneeRepository;
    private readonly IMapper _mapper;

    public AssigneeService(IAssigneeRepository assigneeRepository, IMapper mapper)
    {
        _assigneeRepository = assigneeRepository;
        _mapper = mapper;
    }

    public IReadOnlyCollection<AssigneeDto> GetAllAssignees()
    {
        return _mapper.Map<IReadOnlyCollection<AssigneeDto>>(_assigneeRepository.GetAllAssignees());
    }

    public AssigneeDto GetAssignee(int assigneeId)
    {
        return _mapper.Map<AssigneeDto>(_assigneeRepository.GetAssignee(assigneeId));
    }

    public void DeleteAssignee(int assigneeId)
    {
        _assigneeRepository.DeleteAssignee(assigneeId);
    }

    public int InsertAssignee(AssigneeInsertDto assigneeDTO)
    {
        var mappedAssignee = _mapper.Map<Domain.Models.Assignee>(assigneeDTO);
        _assigneeRepository.InsertAssignee(mappedAssignee);
        return mappedAssignee.Id;
    }

    public void UpdateAssignee(AssigneeInsertDto assigneeDTO, int assigneeId)
    {
        var mappedAssignee = _mapper.Map<Domain.Models.Assignee>(assigneeDTO);
        mappedAssignee.Id = assigneeId;

        _assigneeRepository.UpdateAssignee(mappedAssignee);
    }
}
