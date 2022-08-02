using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Interfaces
{
    public interface IStatsRepository
    {
        List<Stats> GetAllStats();
        Stats GetStats(int statsId);
        int InsertStats(int statsId);
        void DeleteStats(int statsId);
        void UpdateStats(int statsId);
    }
}
