using AutoMapper;
using ToDoList.Api.Bucket.Models;

namespace ToDoList.Api.Bucket.MappingProfiles;

public class BucketServiceMappingProfile : Profile
{
    public BucketServiceMappingProfile()
    {
        CreateMap<Domain.Models.Bucket, BucketDto>().ReverseMap();
        CreateMap<Domain.Models.Bucket, BucketUpsertDto>().ReverseMap();
    }
}
