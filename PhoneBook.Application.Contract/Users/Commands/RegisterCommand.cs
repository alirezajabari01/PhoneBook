using MediatR;
using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.Contract.Users.Commands;

public record RegisterCommand(
    string UserName,
    string Password
) : IBaseCommand;