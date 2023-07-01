using AutoMapper;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Domain.Models;

namespace ToDoList.Api.BucketTasks.MappingProfiles;

public class BucketTaskMappingProfile : Profile
{
    public BucketTaskMappingProfile()
    {
        CreateMap<BucketTask, BucketTaskDto>().ReverseMap();
        CreateMap<BucketTask, BucketUpsertTaskDto>().ReverseMap();
    }
}
