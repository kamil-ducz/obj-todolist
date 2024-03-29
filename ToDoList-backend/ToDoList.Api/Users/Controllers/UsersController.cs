﻿using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Users.Authorization;
using ToDoList.Api.Users.Models;
using ToDoList.Api.Users.Services;

namespace ToDoList.Api.Users.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult InsertNewUser(UserUpsertDto user)
    {
        int? userId = _userService.InsertNewUser(user);
        if (userId == null)
        {
            return Conflict();
        }
        return Created(Request.GetEncodedUrl() + "/" + userId, _userService.GetById((int)userId));
    }
}
