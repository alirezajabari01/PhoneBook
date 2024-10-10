using MediatR;

namespace PhoneBook.MediatR.Mediator;

public interface IBaseCommand<out TData> : IRequest<TData>
{
}

public interface IBaseCommand : IRequest
{
}