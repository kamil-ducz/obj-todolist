using System.Collections.Generic;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Stats.Services
{
    public class StatsService
    {
        public IStats StatsRepository { get; }

        public StatsService(IStats statsRepository)
        {
            StatsRepository = statsRepository;
        }

        public List<Domain.Models.Stats> GetStats()
        {
            return StatsRepository.GetAllStats();
        }

        public Domain.Models.Stats GetStats(int id)
        {
            return StatsRepository.GetStats(id);
        }

    }
}
