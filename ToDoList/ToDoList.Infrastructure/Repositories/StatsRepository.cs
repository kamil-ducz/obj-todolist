using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Repositories
{
    public class StatsRepository : IStatsRepository
    {
        public List<Stats> GetAllStats()
        {
            return Database.GetAllStats();
        }

        public Stats GetStats(int statsId)
        {
            return Database.GetStats(statsId);
        }

        public void DeleteStats(int statsId)
        {
            throw new NotImplementedException();
        }

        public int InsertStats(int statsId)
        {
            throw new NotImplementedException();
        }

        public void UpdateStats(int statsId)
        {
            throw new NotImplementedException();
        }
    }
}
