using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Asignee.Models;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Validation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.Asignee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsigneeController : ControllerBase
    {
        private readonly IAssigneeService assigneeService;
        private readonly AssigneeDTOValidator _assigneeDTOValidator;

        public AsigneeController(IAssigneeService assigneeService, AssigneeDTOValidator assigneeDTOValidator)
        {
            this.assigneeService = assigneeService;
            this._assigneeDTOValidator = assigneeDTOValidator;
        }

        [HttpGet]
        public IEnumerable<Domain.Models.Assignee> Get()
        {
            return assigneeService.GetAllAssignees();
        }

        [HttpGet("{id}")]
        public Domain.Models.Assignee Get(int id)
        {
            return assigneeService.GetAssignee(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AssigneeDTO assigneeDTO)
        {
            _assigneeDTOValidator.ValidateAndThrow(assigneeDTO);

            return Ok();
        }

        // PUT api/<AsigneeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AsigneeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
