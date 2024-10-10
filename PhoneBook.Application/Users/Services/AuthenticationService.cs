using PhoneBook.Application.Contract.Users.Commands;
using PhoneBook.Application.Contract.Users.Contracts;
using PhoneBook.Application.Security;
using PhoneBook.Domain.Users;
using PhoneBook.Domain.Users.Contracts;

namespace PhoneBook.Application.Users.Services;

public class AuthenticationService(
    IUserRepository userRepository,
    IUserNameDuplicateChecker userNameDuplicateChecker) : IAuthenticationService
{
    public async Task Register(RegisterCommand command, CancellationToken cancellationToken)
    {
        var user = new User
        (
            command.UserName,
            command.Password.Salterhash(),
            userNameDuplicateChecker
        );

        await userRepository.AddAsync(user, cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);
    }
}