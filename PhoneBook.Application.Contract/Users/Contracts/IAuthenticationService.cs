using PhoneBook.Application.Contract.Users.Commands;
using PhoneBook.Domain.Abstractions;

namespace PhoneBook.Application.Contract.Users.Contracts;

public interface IAuthenticationService : IScopeLifeTime
{
    Task Register(RegisterCommand command);
}