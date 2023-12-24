namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    // AuthenticationResponse Login(LoginRequest request);
    // AuthenticationResponse Register(RegisterRequest request);
    AuthenticationResult Login(string email, string password);
    AuthenticationResult Register(string firstName, string lastName, string email, string password);
}