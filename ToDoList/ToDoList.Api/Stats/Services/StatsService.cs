using System.Collections.Generic;
using ToDoList.Api.Interfaces;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Stats.Services
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository statsRepository;

        public StatsService(IStatsRepository statsRepository)
        {
            this.statsRepository = statsRepository;
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
            throw new System.NotImplementedException();
        }

        public int InsertStats(Domain.Models.Stats stats)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateStats(Domain.Models.Stats stats)
        {
            throw new System.NotImplementedException();
        }
    }
}
