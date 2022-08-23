using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Stats.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.Stats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService statsService;
        private readonly IValidator<StatsDTO> _statsDTOValidator;

        public StatsController(IStatsService statsService, IValidator<StatsDTO> statsDTOValidator)
        {
            this.statsService = statsService;
            this._statsDTOValidator = statsDTOValidator;
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
