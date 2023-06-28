using AutoMapper;
using ToDoList.Api.Bucket.Models;
using ToDoList.Domain.Models;

namespace ToDoList.Api.MappingProfiles;

public class BucketServiceMappingProfile : Profile
{
    public BucketServiceMappingProfile()
    {
        CreateMap<Buckets, BucketDto>().ReverseMap();
        CreateMap<Buckets, BucketUpsertDto>().ReverseMap();
    }
}
