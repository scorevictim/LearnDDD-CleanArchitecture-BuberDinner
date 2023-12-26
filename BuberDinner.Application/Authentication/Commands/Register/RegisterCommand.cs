using BuberDinner.Application.Authentication.Common;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FristName,
    string LastName,
    string Email,
    string Password) : IRequest<AuthenticationResult>;
