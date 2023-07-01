using System.Collections.Generic;
using AutoMapper;
using ToDoList.Api.Assignees.Models;
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

    public int InsertAssignee(AssigneeUpsertDto assigneeDto)
    {
        var mappedAssignee = _mapper.Map<Domain.Models.Assignee>(assigneeDto);
        _assigneeRepository.InsertAssignee(mappedAssignee);
        return mappedAssignee.Id;
    }

    public void UpdateAssignee(AssigneeUpsertDto assigneeDto, int assigneeId)
    {
        var mappedAssignee = _mapper.Map<Domain.Models.Assignee>(assigneeDto);
        mappedAssignee.Id = assigneeId;

        _assigneeRepository.UpdateAssignee(mappedAssignee);
    }
}
