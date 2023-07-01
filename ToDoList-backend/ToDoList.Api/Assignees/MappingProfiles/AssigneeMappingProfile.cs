using AutoMapper;
using ToDoList.Api.Assignees.Models;
using ToDoList.Domain.Models;

namespace ToDoList.Api.Assignees.MappingProfiles;

public class AssigneeMappingProfile : Profile
{
    public AssigneeMappingProfile()
    {
        CreateMap<Assignee, AssigneeDto>().ReverseMap();
        CreateMap<Assignee, AssigneeUpsertDto>().ReverseMap();
    }
}
