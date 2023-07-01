using AutoMapper;
using ToDoList.Api.Assignees.Models;

namespace ToDoList.Api.Assignees.MappingProfiles;

public class AssigneeServiceMappingProfile : Profile
{
    public AssigneeServiceMappingProfile()
    {
        CreateMap<Domain.Models.Assignee, AssigneeDto>().ReverseMap();
        CreateMap<Domain.Models.Assignee, AssigneeUpsertDto>().ReverseMap();
    }
}
