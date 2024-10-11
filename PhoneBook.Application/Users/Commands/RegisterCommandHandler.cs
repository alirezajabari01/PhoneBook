using PhoneBook.Application.Contract.Users.Commands;
using PhoneBook.Application.Security;
using PhoneBook.Domain.Users;
using PhoneBook.Domain.Users.Contracts;
using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.Users.Commands;

public class RegisterCommandHandler(IUserRepository userRepository,IUserNameDuplicateChecker userNameDuplicateChecker)
    : IBaseCommandHandler<RegisterCommand>
{
    public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    { 
        var user = new User
        (
            request.UserName,
            request.Password.Salterhash(),
            userNameDuplicateChecker
        );

        await userRepository.AddAsync(user, cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);
    }
}