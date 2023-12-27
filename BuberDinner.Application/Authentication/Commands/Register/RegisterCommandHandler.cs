using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    private readonly IUserRepository userRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        this.userRepository = userRepository;
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Check if user already exists
        if (userRepository.GetUserByEmail(command.Email) is not null)
        {
            throw new DuplicateEmailException();
        }

        // Create user (generate unique Id) & persist to DB
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        userRepository.Add(user);

        // Create JWT Token
        var token = jwtTokenGenerator.GenerateToken(user);

        return new(user, token);
    }
}
