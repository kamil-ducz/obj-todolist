using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Asignee.Models;
using ToDoList.Api.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.Asignee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsigneeController : ControllerBase
    {
        private readonly IAssigneeService assigneeService;
        private readonly IValidator<AssigneeDTO> _assigneeDTOValidator;
        private readonly IMapper _mapper;

        public AsigneeController(IAssigneeService assigneeService, IValidator<AssigneeDTO> assigneeDTOValidator, IMapper mapper)
        {
            this.assigneeService = assigneeService;
            this._assigneeDTOValidator = assigneeDTOValidator;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Domain.Models.Assignee> Get()
        {
            // TODO think if validate and throw worth it here?

            return assigneeService.GetAllAssignees();
        }

        [HttpGet("{id}")]
        public Domain.Models.Assignee Get(int id)
        {
            // TODO think if validate and throw worth it here?

            return assigneeService.GetAssignee(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AssigneeDTO assigneeDTO)
        {
            _assigneeDTOValidator.ValidateAndThrow(assigneeDTO);

            var assigneeId = assigneeService.InsertAssignee(assigneeDTO);

            return Ok($"Assignee with id={ assigneeId } inserted into database.");
        }

        // PUT api/<AsigneeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AsigneeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var assigneeToDelete = assigneeService.GetAssignee(id);

            var mappedAssignee = _mapper.Map<AssigneeDTO>(assigneeToDelete);

            _assigneeDTOValidator.ValidateAndThrow(mappedAssignee);

            assigneeService.DeleteAssignee(id);

            return Ok($"Assignee with id={ id } deleted.");
        }
    }
}
