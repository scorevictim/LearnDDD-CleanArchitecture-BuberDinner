using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
[ApiController]
//[ErrorHandlingFilter]
public class AuthenticationController(
    ISender mediator,
    IMapper mapper
    ) : ControllerBase
{
    private readonly ISender mediator = mediator;
    private readonly IMapper mapper = mapper;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = mapper.Map<RegisterCommand>(request);
        AuthenticationResult authResult = await mediator.Send(command);
        var response = mapper.Map<AuthenticationResponse>(authResult);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = mapper.Map<LoginQuery>(request);
        var authResult = await mediator.Send(query);
        var response = mapper.Map<AuthenticationResponse>(authResult);
        return Ok(response);
    }
}
