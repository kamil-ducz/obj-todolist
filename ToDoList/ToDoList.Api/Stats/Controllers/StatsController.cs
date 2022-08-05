using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Api.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.Stats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService statsService;

        public StatsController(IStatsService statsService)
        {
            this.statsService = statsService;
        }

        // GET: api/<StatsController>
        [HttpGet]
        public IEnumerable<Domain.Models.Stats> Get()
        {
            return statsService.GetAllStats();
        }

        // GET api/<StatsController>/5
        [HttpGet("{id}")]
        public Domain.Models.Stats Get(int id)
        {
            return statsService.GetStats(id);
        }

        // POST api/<StatsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
