using AutoMapper;
using ToDoList.Api.BucketTasks.Models;

namespace ToDoList.Api.BucketTasks.MappingProfiles;

public class BucketTaskServiceMappingProfile : Profile
{
    public BucketTaskServiceMappingProfile()
    {
        CreateMap<Domain.Models.BucketTask, BucketTaskDto>().ReverseMap();
        CreateMap<Domain.Models.BucketTask, BucketUpsertTaskDto>().ReverseMap();
    }
}
