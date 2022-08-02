using System.Collections.Generic;

namespace ToDoList.Api.Interfaces
{
    public interface IStatsService
    {
        List<Domain.Models.Stats> GetAllStats();
        Domain.Models.Stats GetStats(int statsId);
        int InsertStats(int statsId);
        void DeleteStats(int statsId);
        void UpdateStats(int statsId);
    }
}
