using AutoMapper;
using ToDoList.Api.Buckets.Models;

namespace ToDoList.Api.Buckets.MappingProfiles;

public class BucketMappingProfile : Profile
{
    public BucketMappingProfile()
    {
        CreateMap<Domain.Models.Bucket, BucketDto>().ReverseMap();
        CreateMap<Domain.Models.Bucket, BucketUpsertDto>().ReverseMap();
    }
}
