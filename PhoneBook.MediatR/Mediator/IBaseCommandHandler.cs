using MediatR;
using PhoneBook.Domain.Abstractions;

namespace PhoneBook.MediatR.Mediator;

public interface IBaseCommandHandler<in TCommand, TResponseData> : IScopeLifeTime,
    IRequestHandler<TCommand, TResponseData>
    where TCommand : IBaseCommand<TResponseData>
{
}

public interface IBaseCommandHandler<in TCommand> : IScopeLifeTime, IRequestHandler<TCommand>
    where TCommand : IBaseCommand
{
}