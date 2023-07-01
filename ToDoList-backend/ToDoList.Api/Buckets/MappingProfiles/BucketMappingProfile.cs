using AutoMapper;
using ToDoList.Api.Buckets.Models;
using ToDoList.Domain.Models;

namespace ToDoList.Api.Buckets.MappingProfiles;

public class BucketMappingProfile : Profile
{
    public BucketMappingProfile()
    {
        CreateMap<Bucket, BucketDto>().ReverseMap();
        CreateMap<Bucket, BucketUpsertDto>().ReverseMap();
    }
}
