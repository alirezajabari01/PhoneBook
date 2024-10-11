using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Controllers.BaseControllers;
using PhoneBook.Application.Contract.Users.Commands;
using PhoneBook.Application.Contract.Users.Responses;

namespace PhoneBook.Api.Controllers;

public class AuthenticationController(IMediator mediator) : ApiController
{
    [HttpPost]
    public async Task Register(RegisterCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    [HttpPost("[action]")]
    public async Task<LoginResponse> Login(LoginCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);
}