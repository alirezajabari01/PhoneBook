using PhoneBook.Application.Contract.Users.Responses;
using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.Contract.Users.Commands;

public record LoginCommand(string UserName, string Password):IBaseCommand<LoginResponse>;