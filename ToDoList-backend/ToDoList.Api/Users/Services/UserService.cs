﻿using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Api.Users.Authorization;
using ToDoList.Api.Users.Models;
using ToDoList.Domain.Models;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Users.Services;

public interface IUserService
{
    AuthenticateResponse? Authenticate(AuthenticateRequest model);
    IEnumerable<UserDto> GetAll();
    User? GetById(int id);
    public int? InsertNewUser(UserUpsertDto user);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtUtils _jwtUtils;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;
    private IEnumerable<UserDto> _users = new List<UserDto>();

    public UserService(IUserRepository userRepository, IJwtUtils jwtUtils, IEmailService emailService, IMapper mapper)
    {
        _userRepository = userRepository;
        _jwtUtils = jwtUtils;
        _emailService = emailService;
        _mapper = mapper;
    }

    public AuthenticateResponse? Authenticate(AuthenticateRequest model)
    {
        _users = GetAll();
        var user = _users.SingleOrDefault(x => x.Username == model.Username);

        // return null if user not found
        if (user == null)
        {
            return null;
        }

        // return null if user-typed password hash not match hashed password in db
        if (!AuthenticationService.VerifyPassword(user.Password, model.Password))
        {
            return null;
        }

        // authentication successful so generate jwt token
        var token = _jwtUtils.GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public IEnumerable<UserDto> GetAll()
    {
        return _mapper.Map<IEnumerable<UserDto>>(_userRepository.GetAllUsers());
    }

    public User? GetById(int id)
    {
        return _userRepository.GetUser(id);
    }

    public int? InsertNewUser(UserUpsertDto user)
    {
        var userToInsert = _mapper.Map<User>(user);
        if (_userRepository.GetAllUsers().Any(u => u.Username == userToInsert.Username))
        {
            return null;
        }

        userToInsert.Password = BCrypt.Net.BCrypt.HashPassword(userToInsert.Password);
        _userRepository.InsertUser(userToInsert);
        // _emailService.SendWelcomeEmail(user); disabled due to Google newest security policies
        return userToInsert.Id;
    }
}
