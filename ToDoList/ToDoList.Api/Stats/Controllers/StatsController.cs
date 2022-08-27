using AutoMapper;
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
        private readonly IMapper _mapper;

        public StatsController(IStatsService statsService, IValidator<StatsDTO> statsDTOValidator, IMapper mapper)
        {
            this.statsService = statsService;
            this._statsDTOValidator = statsDTOValidator;
            this._mapper = mapper;
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
            _statsDTOValidator.ValidateAndThrow(statsDTO);

            var statsId = statsService.InsertStats(statsDTO);

            return Ok($"Statistic with id={ statsId } inserted into database.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StatsDTO statsDTO)
        {
            _statsDTOValidator.ValidateAndThrow(statsDTO);

            statsService.UpdateStats(id, statsDTO);

            return Ok($"Stats with id={ id } has been updated.");


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var statsToDelete = statsService.GetStats(id);

            var mappedStats = _mapper.Map<StatsDTO>(statsToDelete);

            _statsDTOValidator.ValidateAndThrow(mappedStats);

            statsService.DeleteStats(id);

            return Ok($"Stats with id={ id } deleted.");
        }
    }
}
