using AutoMapper;
using ToDoList.Api.Asignee.Models;
using ToDoList.Domain.Models;

namespace ToDoList.Api.MappingProfiles;

public class AssigneeServiceMappingProfile : Profile
{
    public AssigneeServiceMappingProfile()
    {
        CreateMap<Assignees, AssigneeDto>().ReverseMap();
        CreateMap<Assignees, AssigneeUpsertDto>().ReverseMap();
    }
}
