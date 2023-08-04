using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.Users.Authorization;
using ToDoList.Api.Users.Helpers;
using ToDoList.Api.Users.MappingProfiles;
using ToDoList.Api.Users.Models;
using ToDoList.Api.Users.Services;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Test.Services;

[TestFixture]
public class UserServiceTest
{
    private Mock<IUserRepository> _userRepositoryMock;
    private IUserService _userService;
    private IMapper _mapper;
    private IJwtUtils _jwtUtils;
    private IEmailService _emailServiceMock;

    [SetUp]
    public void Setup()
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new UserMappingProfile());
        });
        var mapper = mapperConfig.CreateMapper();
        _mapper = mapper;
        var appSettings = new AppSettings
        {
            Secret = "This is a secret authentication phase which should be always unique for the application"
        };
        IOptions<AppSettings> appSettingsOptions = Options.Create(appSettings);
        _jwtUtils = new JwtUtils(appSettingsOptions);
        var smtpSettingsMock = new Mock<IOptions<SmtpSettings>>();
        _emailServiceMock = new EmailService(smtpSettingsMock.Object);

        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepositoryMock.Object, _jwtUtils, _emailServiceMock, _mapper);
    }

    [Test]
    public void GetUsers_ReturnUsers()
    {
        // Arrange
        var expectedUsers = new List<UserDto>()
        {
            new UserDto(1, "John", "Doe", "JD", "john.doe@alfa.com", "test123"),
            new UserDto(2, "Erick", "Gold", "EG", "eg@beta.com", "test123"),
        };

        _userRepositoryMock.Setup(repo => repo.GetAllUsers())
            .Returns(() => expectedUsers.Select(b => new User
            {
                Id = b.Id,
                FirstName = b.FirstName,
                LastName = b.LastName,
                Username = b.Username,
                Email = b.Email,
                Password = b.Password,
            }).ToList());

        // Act 
        var result = _userService.GetAll();

        // Assert
        expectedUsers.Should().BeEquivalentTo(result);
    }

    [Test]
    public void GetUser_ReturnUser()
    {
        // Arrange
        var expectedUserDto = new UserDto(1, "John", "Doe", "JD", "john.doe@alfa.com", "test123");

        var expectedUser = _mapper.Map<User>(expectedUserDto);
        _userRepositoryMock.Setup(repo => repo.GetUser(1)).Returns(expectedUser);

        // Act
        var result = _userService.GetById(1);

        // Assert
        expectedUser.Should().BeEquivalentTo(result);
    }

    [Test]
    public void InsertUser_ReturnUserId()
    {
        // Arrange
        var expectedUsers = new List<UserDto>()
        {
            new UserDto(1, "John", "Doe", "JD", "john.doe@alfa.com", "test123"),
            new UserDto(2, "Erick", "Gold", "EG", "eg@beta.com", "test123"),
        };

        var expectedUserId = 3;

        _userRepositoryMock.Setup(repo => repo.GetAllUsers())
            .Returns(() => expectedUsers.Select(b => new User
            {
                Id = b.Id,
                FirstName = b.FirstName,
                LastName = b.LastName,
                Username = b.Username,
                Email = b.Email,
                Password = b.Password,
            }).ToList());

        // Act
        var result = _userService.InsertNewUser(new UserUpsertDto(3, "Butch", "Mustache", "BM", "butchm@teta.com", "test321"));

        // Assert
        expectedUserId.Should().Be(result);
    }

    [Test]
    public void AuthenticateRequest_ReturnAuthenticateResponse()
    {
        // Arrange
        var expectedUsers = new List<UserDto>()
        {
            new UserDto(1, "John", "Doe", "JD", "john.doe@alfa.com", "test123"),
            new UserDto(2, "Erick", "Gold", "EG", "eg@beta.com", "test123"),
        };

        _userRepositoryMock.Setup(repo => repo.GetAllUsers())
            .Returns(() => expectedUsers.Select(b => new User
            {
                Id = b.Id,
                FirstName = b.FirstName,
                LastName = b.LastName,
                Username = b.Username,
                Email = b.Email,
                Password = b.Password,
            }).ToList());

        var expectedUserDto = new UserDto(1, "John", "Doe", "JD", "john.doe@alfa.com", "test123");
        var expectedToken = _jwtUtils.GenerateJwtToken(expectedUserDto); // verify token generation mechanism

        var authenticateRequest = new AuthenticateRequest(expectedUserDto.Username, expectedUserDto.Password);
        var expectedAuthenticateResponse = new AuthenticateResponse(expectedUserDto, expectedToken);

        _userService = new UserService(_userRepositoryMock.Object, _jwtUtils, _emailServiceMock, _mapper);

        // Act 
        var authenticateResponse = _userService.Authenticate(authenticateRequest);
        authenticateResponse.Token = expectedToken; // assign generated token for response so that assertion successes

        // Assert
        expectedAuthenticateResponse.Should().BeEquivalentTo(authenticateResponse);
    }
}
