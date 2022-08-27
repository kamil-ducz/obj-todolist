using AutoMapper;
using System.Collections.Generic;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Stats.Models;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Stats.Services
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository statsRepository;
        private readonly IMapper mapper;

        public StatsService(IStatsRepository statsRepository, IMapper mapper)
        {
            this.statsRepository = statsRepository;
            this.mapper = mapper;
        }

        public List<Domain.Models.Stats> GetAllStats()
        {
            return statsRepository.GetAllStats();
        }

        public Domain.Models.Stats GetStats(int statsId)
        {
            return statsRepository.GetStats(statsId);
        }

        public void DeleteStats(int statsId)
        {
            statsRepository.DeleteStats(statsId);
        }

        public int InsertStats(StatsDTO statsDTO)
        {
            var mappedStats = mapper.Map<Domain.Models.Stats>(statsDTO);

            return statsRepository.InsertStats(mappedStats);
        }

        public void UpdateStats(Domain.Models.Stats stats)
        {
            throw new System.NotImplementedException();
        }
    }
}
