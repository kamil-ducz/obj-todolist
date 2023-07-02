﻿using AutoMapper;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.BucketTask.MappingProfiles;

public class BucketTaskServiceMappingProfile : Profile
{
    public BucketTaskServiceMappingProfile()
    {
        CreateMap<Domain.Models.BucketTask, BucketTaskDto>().ReverseMap();
        CreateMap<Domain.Models.BucketTask, BucketUpsertTaskDto>().ReverseMap();
    }
}
