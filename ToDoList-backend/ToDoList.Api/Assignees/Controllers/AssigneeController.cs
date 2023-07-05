using FluentValidation;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Assignees.Models;
using ToDoList.Api.Assignees.Services;

namespace ToDoList.Api.Assignees.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssigneeController : ControllerBase
{
    private readonly IAssigneeService _assigneeService;
    private readonly IValidator<AssigneeUpsertDto> _assigneeInsertDtoValidator;

    public AssigneeController(IAssigneeService assigneeService, IValidator<AssigneeUpsertDto> assigneeDTOValidator)
    {
        _assigneeService = assigneeService;
        _assigneeInsertDtoValidator = assigneeDTOValidator;
    }

    [HttpGet]
    public IReadOnlyCollection<AssigneeDto> Get()
    {
        return _assigneeService.GetAllAssignees();
    }

    [HttpGet("{id}")]
    public AssigneeDto Get(int id)
    {
        return _assigneeService.GetAssignee(id);
    }

    [HttpPost]
    public IActionResult Post(AssigneeUpsertDto assigneeInsertDto)
    {
        _assigneeInsertDtoValidator.ValidateAndThrow(assigneeInsertDto);
        var assigneeId = _assigneeService.InsertAssignee(assigneeInsertDto);

        return Created(Request.GetEncodedUrl() + "/" + assigneeId, _assigneeService.GetAssignee(assigneeId));
    }

    [HttpPut("{id}")]
    public IActionResult Put(AssigneeUpsertDto assigneeInsertDTO, int id)
    {
        _assigneeInsertDtoValidator.ValidateAndThrow(assigneeInsertDTO);
        _assigneeService.UpdateAssignee(assigneeInsertDTO, id);

        return Ok(_assigneeService.GetAssignee(id));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _assigneeService.DeleteAssignee(id);

        return NoContent();
    }
}