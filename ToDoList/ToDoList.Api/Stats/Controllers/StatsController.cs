using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Stats.Models;
using ToDoList.Api.Validation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.Stats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService statsService;
        private readonly StatsDTOValidator _statsDTOValidator;

        public StatsController(IStatsService statsService, StatsDTOValidator statsDTOValidator)
        {
            this.statsService = statsService;
            _statsDTOValidator = statsDTOValidator;
        }

        [HttpGet]
        public IEnumerable<Domain.Models.Stats> Get()
        {
            return statsService.GetAllStats();
        }

        [HttpGet("{id}")]
        public Domain.Models.Stats Get(int id)
        {
            return statsService.GetStats(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] StatsDTO statsDTO)
        {
            _statsDTOValidator.Validate(statsDTO);

            return Ok();
        }

        // PUT api/<StatsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
