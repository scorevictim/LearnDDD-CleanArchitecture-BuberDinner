﻿using BuberDinner.Api.Filters;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
[ApiController]
//[ErrorHandlingFilter]
public class AuthenticationController(
    IAuthenticationService authenticationService
    ) : ControllerBase
{
    private readonly IAuthenticationService authenticationService = authenticationService;

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = authenticationService.Login(
            request.Email,
            request.Password
        );
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
        return Ok(response);
    }
}
