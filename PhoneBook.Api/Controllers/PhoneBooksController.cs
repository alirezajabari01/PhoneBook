using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Controllers.BaseControllers;
using PhoneBook.Application.Contract.PhoneBooks.Commands;
using PhoneBook.Application.Contract.PhoneBooks.Requests;

namespace PhoneBook.Api.Controllers;

public class PhoneBooksController(IMediator mediator) : ApiController
{
    [HttpPost]
    public async Task Add(AddPhoneBookCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    [HttpPut]
    public async Task Update(UpdatePhoneBookCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    [HttpGet("[action]")]
    public async Task<GetPhoneBookByIdResponse> GetById([FromQuery] GetPhoneBookByIdRequest requesst,
        CancellationToken cancellationToken)
        => await mediator.Send(requesst, cancellationToken);

    [HttpGet]
    public async Task<List<GetAllPhoneBooksResponse>> GetAll([FromQuery] GetAllPhoneBooksRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(request, cancellationToken);

    [HttpDelete]
    public async Task Delete(DeletePhoneBookCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);
}