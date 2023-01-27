﻿using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces
{
    public interface IStatsRepository
    {
        List<Stats> GetAllStats();
        Stats GetStats(int statsId);
        int InsertStats(Stats stats);
        void DeleteStats(int statsId);
        void UpdateStats(int id, Stats stats);
    }
}
