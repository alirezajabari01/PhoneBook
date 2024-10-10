using MediatR;

namespace PhoneBook.MediatR.Mediator;

public interface IBaseQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IBaseQuery<TResponse>
{
}