using MediatR;
using PhoneBook.Domain.Abstractions;

namespace PhoneBook.MediatR.Mediator;

public interface IBaseQueryHandler<in TQuery, TResponse> : IScopeLifeTime, IRequestHandler<TQuery, TResponse>
    where TQuery : IBaseQuery<TResponse>
{
}