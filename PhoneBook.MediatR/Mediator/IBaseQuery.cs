using MediatR;

namespace PhoneBook.MediatR.Mediator;

public interface IBaseQuery<out TResponse> : IRequest<TResponse>
{
}