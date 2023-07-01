using AutoMapper;
using ToDoList.Api.Bucket.Models;
using ToDoList.Domain.Models;

namespace ToDoList.Api.Bucket.MappingProfiles;

public class BucketServiceMappingProfile : Profile
{
    public BucketServiceMappingProfile()
    {
        CreateMap<Domain.Models.Bucket, BucketDto>().ReverseMap();
        CreateMap<Domain.Models.Bucket, BucketUpsertDto>().ReverseMap();
    }
}
