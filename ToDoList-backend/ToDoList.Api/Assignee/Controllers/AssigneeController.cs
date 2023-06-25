using AutoMapper;
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
    private readonly IValidator<AssigneeDto> _assigneeDTOValidator;
    private readonly IMapper _mapper;

    public AssigneeController(IAssigneeService assigneeService, IValidator<AssigneeDto> assigneeDTOValidator, IMapper mapper)
    {
        _assigneeService = assigneeService;
        _assigneeDTOValidator = assigneeDTOValidator;
        _mapper = mapper;
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
    public IActionResult Post([FromBody] AssigneeDto assigneeDTO)
    {
        _assigneeDTOValidator.ValidateAndThrow(assigneeDTO);

        var assigneeId = _assigneeService.InsertAssignee(assigneeDTO);

        return Created(Request.GetEncodedUrl() + "/" + assigneeId, assigneeDTO);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AssigneeDto assigneeDTO)
    {
        _assigneeDTOValidator.ValidateAndThrow(assigneeDTO);

        _assigneeService.UpdateAssignee(id, assigneeDTO);

        return Ok(assigneeDTO);


    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var assigneeToDelete = _assigneeService.GetAssignee(id);

        var mappedAssignee = _mapper.Map<AssigneeDto>(assigneeToDelete);

        _assigneeDTOValidator.ValidateAndThrow(mappedAssignee);

        _assigneeService.DeleteAssignee(id);

        return Ok(mappedAssignee);
    }
}
