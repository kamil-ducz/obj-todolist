using AutoMapper;
using ToDoList.Api.Users.Models;
using ToDoList.Domain.Models;

namespace ToDoList.Api.Users.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserUpsertDto>().ReverseMap();
    }
}
