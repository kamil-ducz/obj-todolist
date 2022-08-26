using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Repositories
{
    public class StatsRepository : IStatsRepository
    {
        private readonly ToDoListDbContext _toDoListDbContext;

        public StatsRepository(ToDoListDbContext toDoListDbContext)
        {
            this._toDoListDbContext = toDoListDbContext;
        }

        public List<Stats> GetAllStats()
        {
            if (_toDoListDbContext.Stats is not null)
            {
                return _toDoListDbContext.Stats.ToList();
            }

            throw new NotImplementedException();
        }

        public Stats GetStats(int statsId)
        {
            if (_toDoListDbContext.Stats is not null)
            {
                return _toDoListDbContext.Stats.First(a => a.Id == statsId);
            }

            throw new NotImplementedException();
        }

        public void DeleteStats(int statsId)
        {
            throw new NotImplementedException();
        }

        public int InsertStats(Stats stats)
        {
            throw new NotImplementedException();
        }

        public void UpdateStats(Stats stats)
        {
            throw new NotImplementedException();
        }
    }
}
