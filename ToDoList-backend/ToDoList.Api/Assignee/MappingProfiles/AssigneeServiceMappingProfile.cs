using AutoMapper;
using ToDoList.Api.Assignee.Models;

namespace ToDoList.Api.Assignee.MappingProfiles;

public class AssigneeServiceMappingProfile : Profile
{
    public AssigneeServiceMappingProfile()
    {
        CreateMap<Domain.Models.Assignee, AssigneeDto>().ReverseMap();
        CreateMap<Domain.Models.Assignee, AssigneeUpsertDto>().ReverseMap();
    }
}
