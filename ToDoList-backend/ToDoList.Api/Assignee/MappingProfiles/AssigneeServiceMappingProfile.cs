﻿using AutoMapper;
using ToDoList.Api.Asignee.Models;

namespace ToDoList.Api.MappingProfiles;

public class AssigneeServiceMappingProfile : Profile
{
    public AssigneeServiceMappingProfile()
    {
        CreateMap<Domain.Models.Assignee, AssigneeDto>().ReverseMap();
        CreateMap<Domain.Models.Assignee, AssigneeInsertDto>().ReverseMap();
    }
}
