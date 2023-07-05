using AutoMapper;
using ToDoList.Api.Assignees.Models;

namespace ToDoList.Api.Assignees.MappingProfiles;

public class AssigneeMappingProfile : Profile
{
    public AssigneeMappingProfile()
    {
        CreateMap<Domain.Models.Assignee, AssigneeDto>().ReverseMap();
        CreateMap<Domain.Models.Assignee, AssigneeUpsertDto>().ReverseMap();
    }
}
