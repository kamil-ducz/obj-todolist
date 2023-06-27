using FluentValidation;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Asignee.Models;
using ToDoList.Api.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.Asignee.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssigneeController : ControllerBase
{
    private readonly IAssigneeService _assigneeService;
    private readonly IValidator<AssigneeInsertDto> _assigneeInsertDtoValidator;

    public AssigneeController(IAssigneeService assigneeService, IValidator<AssigneeInsertDto> assigneeDTOValidator)
    {
        _assigneeService = assigneeService;
        _assigneeInsertDtoValidator = assigneeDTOValidator;
    }

    [HttpGet]
    public IEnumerable<AssigneeDto> Get()
    {
        return _assigneeService.GetAllAssignees();
    }

    [HttpGet("{id}")]
    public AssigneeDto Get(int id)
    {
        return _assigneeService.GetAssignee(id);
    }

    [HttpPost]
    public IActionResult Post(AssigneeInsertDto assigneeInsertDto)
    {
        _assigneeInsertDtoValidator.ValidateAndThrow(assigneeInsertDto);
        var assigneeId = _assigneeService.InsertAssignee(assigneeInsertDto);

        return Created(Request.GetEncodedUrl() + "/" + assigneeId, assigneeInsertDto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(AssigneeInsertDto assigneeInsertDTO, int id)
    {
        _assigneeInsertDtoValidator.ValidateAndThrow(assigneeInsertDTO);
        _assigneeService.UpdateAssignee(assigneeInsertDTO, id);

        return Ok(assigneeInsertDTO);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _assigneeService.DeleteAssignee(id);

        return NoContent();
    }
}