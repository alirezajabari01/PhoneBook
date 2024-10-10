using PhoneBook.Application.Contract.Users.Commands;
using PhoneBook.Application.Contract.Users.Contracts;
using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.Users.Commands;

public class RegisterCommandHandler(IAuthenticationService authenticationService)
    : IBaseCommandHandler<RegisterCommand>
{
    public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await authenticationService.Register(request, cancellationToken);
    }
}