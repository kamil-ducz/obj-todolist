using AutoMapper;
using FluentValidation;
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
    private readonly IValidator<AssigneeDTO> _assigneeDTOValidator;
    private readonly IMapper _mapper;

    public AssigneeController(IAssigneeService assigneeService, IValidator<AssigneeDTO> assigneeDTOValidator, IMapper mapper)
    {
        _assigneeService = assigneeService;
        _assigneeDTOValidator = assigneeDTOValidator;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<Domain.Models.Assignee> Get()
    {
        return _assigneeService.GetAllAssignees();
    }

    [HttpGet("{id}")]
    public Domain.Models.Assignee Get(int id)
    {
        return _assigneeService.GetAssignee(id);
    }

    [HttpPost]
    public IActionResult Post([FromBody] AssigneeDTO assigneeDTO)
    {
        _assigneeDTOValidator.ValidateAndThrow(assigneeDTO);

        var assigneeId = _assigneeService.InsertAssignee(assigneeDTO);

        return Ok($"Assignee with id={assigneeId} inserted into database.");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AssigneeDTO assigneeDTO)
    {
        _assigneeDTOValidator.ValidateAndThrow(assigneeDTO);

        _assigneeService.UpdateAssignee(id, assigneeDTO);

        return Ok($"Assignee with id={id} has been updated.");


    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var assigneeToDelete = _assigneeService.GetAssignee(id);

        var mappedAssignee = _mapper.Map<AssigneeDTO>(assigneeToDelete);

        _assigneeDTOValidator.ValidateAndThrow(mappedAssignee);

        _assigneeService.DeleteAssignee(id);

        return Ok($"Assignee with id={id} deleted.");
    }
}
