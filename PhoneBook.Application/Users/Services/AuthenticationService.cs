using PhoneBook.Application.Contract.Users.Commands;
using PhoneBook.Application.Contract.Users.Contracts;

namespace PhoneBook.Application.Users.Services;

public class AuthenticationService : IAuthenticationService
{
    public Task Register(RegisterCommand command)
    {
        return Task.CompletedTask;
    }
}