using PhoneBook.Application.Contract.Users.Commands;
using PhoneBook.Application.Contract.Users.Responses;
using PhoneBook.Application.Security;
using PhoneBook.Domain.Users.Contracts;
using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.Users.Commands;

public class LoginCommandHandler(IUserRepository userRepository)
    : IBaseCommandHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.SingleOrDefaultAsync
        (
            user => user.UserName.Value == request.UserName &&
                    user.Password.Value == request.Password.Salterhash()
            , cancellationToken
        );

        string token = user.Generate();

        return new LoginResponse(token);
    }
    
}