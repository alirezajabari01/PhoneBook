using MediatR;

namespace PhoneBook.MediatR.Mediator;

public interface IBaseCommandHandler<in TCommand, TResponseData> : IRequestHandler<TCommand, TResponseData>
    where TCommand : IBaseCommand<TResponseData>
{
}