using System.Collections.Generic;
using ToDoList.Api.Stats.Models;

namespace ToDoList.Api.Interfaces
{
    public interface IStatsService
    {
        List<Domain.Models.Stats> GetAllStats();
        Domain.Models.Stats GetStats(int statsId);
        int InsertStats(StatsDTO stats);
        void DeleteStats(int statsId);
        void UpdateStats(int id, StatsDTO stats);
    }
}
