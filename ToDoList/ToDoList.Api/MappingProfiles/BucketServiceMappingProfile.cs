using AutoMapper;
using ToDoList.Api.Bucket.Models;

namespace ToDoList.Api.MappingProfiles
{
    public class BucketServiceMappingProfile : Profile
    {
        public BucketServiceMappingProfile()
        {
            CreateMap<Domain.Models.Bucket, BucketDTO>();
        }
    }
}
