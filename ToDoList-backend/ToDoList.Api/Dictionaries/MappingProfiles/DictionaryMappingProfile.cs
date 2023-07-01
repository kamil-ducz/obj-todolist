using AutoMapper;
using ToDoList.Api.Dictionaries.Models;
using ToDoList.Domain.Models;

namespace ToDoList.Api.Dictionaries.MappingProfiles;

public class DictionaryMappingProfile : Profile
{
    public DictionaryMappingProfile()
    {
        CreateMap<BucketColor, BucketColorDto>();
    }
}