using AutoMapper;
using System.Collections.Generic;
using ToDoList.Api.Assignees.Models;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Assignees.Services;

public interface IAssigneeService
{
    IReadOnlyCollection<AssigneeDto> GetAllAssignees();
    AssigneeDto GetAssignee(int assigneeId);
    int InsertAssignee(AssigneeUpsertDto assignee);
    void DeleteAssignee(int assigneeId);
    void UpdateAssignee(AssigneeUpsertDto assignee, int assigneeId);
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
        var assignee = _assigneeRepository.GetAssignee(assigneeId);
        _assigneeRepository.DeleteAssignee(assignee);
    }

    public int InsertAssignee(AssigneeUpsertDto assigneeDTO)
    {
        var assignee = _mapper.Map<Assignee>(assigneeDTO);
        _assigneeRepository.InsertAssignee(assignee);
        return assignee.Id;
    }

    public void UpdateAssignee(AssigneeUpsertDto assigneeDTO, int assigneeId)
    {
        var assignee = _mapper.Map<Assignee>(assigneeDTO);
        assignee.Id = assigneeId;

        _assigneeRepository.UpdateAssignee(assignee);
    }
}
