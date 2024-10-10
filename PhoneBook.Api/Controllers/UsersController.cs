using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Controllers.BaseControllers;
using PhoneBook.Application.Contract.Users.Commands;

namespace PhoneBook.Api.Controllers;

public class UsersController(IMediator mediator) : ApiController
{
    [HttpPost]
    public async Task Add(RegisterCommand command, CancellationToken cancellationToken)
    {
        await mediator.Send(command, cancellationToken);
    }
}