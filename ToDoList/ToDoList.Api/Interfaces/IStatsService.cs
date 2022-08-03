using System.Collections.Generic;

namespace ToDoList.Api.Interfaces
{
    public interface IStatsService
    {
        List<Domain.Models.Stats> GetAllStats();
        Domain.Models.Stats GetStats(int statsId);
        int InsertStats(Domain.Models.Stats stats);
        void DeleteStats(int statsId);
        void UpdateStats(Domain.Models.Stats stats);
    }
}
