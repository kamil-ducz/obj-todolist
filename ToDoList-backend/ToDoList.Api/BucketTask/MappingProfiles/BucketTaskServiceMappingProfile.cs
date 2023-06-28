using AutoMapper;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Domain.Models;

namespace ToDoList.Api.MappingProfiles;

public class BucketTaskServiceMappingProfile : Profile
{
    public BucketTaskServiceMappingProfile()
    {
        CreateMap<BucketTasks, BucketTaskDto>().ReverseMap();
        CreateMap<BucketTasks, BucketUpsertTaskDto>().ReverseMap();
    }
}
