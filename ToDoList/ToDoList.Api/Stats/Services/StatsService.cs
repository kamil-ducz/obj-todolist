using AutoMapper;
using System.Collections.Generic;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Stats.Models;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Stats.Services
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository statsRepository;
        private readonly ToDoListDbContext toDoListDbContext;
        private readonly IMapper mapper;

        public StatsService(IStatsRepository statsRepository, ToDoListDbContext toDoListDbContext, IMapper mapper)
        {
            this.statsRepository = statsRepository;
            this.toDoListDbContext = toDoListDbContext;
            this.mapper = mapper;
        }

        public List<Domain.Models.Stats> GetAllStats()
        {
            return statsRepository.GetAllStats();
        }

        public Domain.Models.Stats GetStats(int statsId)
        {
            return statsRepository.GetStats(statsId);
        }

        public void DeleteStats(int statsId)
        {
            throw new System.NotImplementedException();
        }

        public int InsertStats(StatsDTO statsDTO)
        {
            if (toDoListDbContext.Stats is not null)
            {
                var mappedBucketTask = mapper.Map<Domain.Models.Stats>(statsDTO);

                toDoListDbContext.Stats.Add(mappedBucketTask);
                toDoListDbContext.SaveChanges();
            }

            return statsDTO.Id;
        }

        public void UpdateStats(Domain.Models.Stats stats)
        {
            throw new System.NotImplementedException();
        }
    }
}
