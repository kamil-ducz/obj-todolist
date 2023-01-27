using AutoMapper;
using ToDoList.Api.Stats.Models;

namespace ToDoList.Api.MappingProfiles
{
    public class StatsServiceMappingProfile : Profile
    {
        public StatsServiceMappingProfile()
        {
            CreateMap<Domain.Models.Stats, StatsDTO>().ReverseMap();
        }
    }
}
