using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.Asignee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsigneeController : ControllerBase
    {
        private readonly IAssigneeService assigneeService;

        public AsigneeController(IAssigneeService assigneeService)
        {
            this.assigneeService = assigneeService;
        }

        // GET: api/<AsigneeController>
        [HttpGet]
        public IEnumerable<Domain.Models.Assignee> Get()
        {
            return assigneeService.GetAllAssignees();
        }

        // GET api/<AsigneeController>/5
        [HttpGet("{id}")]
        public Domain.Models.Assignee Get(int id)
        {
            return assigneeService.GetAssignee(id);
        }

        // POST api/<AsigneeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
