using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    private readonly IUserRepository userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        this.userRepository = userRepository;
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // user does exist
        if (userRepository.GetUserByEmail(query.Email) is not User user)
        {
            throw new Exception("User with given email does not exist");
        }

        // validate password
        if (user.Password != query.Password)
        {
            throw new Exception("Invalid Pasasword");
        }
        // create JWT
        var token = jwtTokenGenerator.GenerateToken(user);

        return new(user, token);
    }
}
