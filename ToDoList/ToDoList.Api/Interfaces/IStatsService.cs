using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces
{
    public interface IStatsService
    {
        List<Stats> GetAllStats();
        Stats GetStats(int statsId);
        int InsertStats(int statsId);
        void DeleteStats(int statsId);
        void UpdateStats(int statsId);
    }
}
