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
            if (_toDoListDbContext.Stats is not null)
            {
                var assigneeToDelete = _toDoListDbContext.Stats.First(a => a.Id == statsId);
                _toDoListDbContext.Stats.Remove(assigneeToDelete);
                _toDoListDbContext.SaveChanges();
            }

            else
            {
                throw new NotImplementedException();
            }
        }

        public int InsertStats(Stats stats)
        {
            if (_toDoListDbContext.Stats is not null)
            {
                _toDoListDbContext.Stats.Add(stats);
                _toDoListDbContext.SaveChanges();

                return stats.Id;
            }

            throw new NotImplementedException();
        }

        public void UpdateStats(int id, Stats stats)
        {
            // TODO if wrong id provided throw custom exception

            if (_toDoListDbContext.Stats is not null)
            {
                var statsToUpdate = _toDoListDbContext.Stats.First(a => a.Id == id);

                statsToUpdate.PercentOfTasksCompleted = stats.PercentOfTasksCompleted;
                statsToUpdate.PercentOfTasksToDo = stats.PercentOfTasksToDo;
                statsToUpdate.PercentOfTasksInProgress = stats.PercentOfTasksInProgress;
                statsToUpdate.PercentOfTasksCancelled = stats.PercentOfTasksCancelled;

                _toDoListDbContext.Stats.Update(statsToUpdate);
                _toDoListDbContext.SaveChanges();
            }

            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
