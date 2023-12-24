using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists

        // Create user (generate unique Id)

        // Create JWT Token
        var userId = Guid.NewGuid();
        var token = jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        
        return new(userId, firstName, lastName, email, token);
    }
    public AuthenticationResult Login(string email, string password)
    {
        return new(Guid.NewGuid(), "firstName", "lastName", email, "token");
    }

}