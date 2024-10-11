using PhoneBook.Application.Contract.PhoneBooks.Requests;
using PhoneBook.Application.UserFilters;
using PhoneBook.Domain.PhoneBooks.Contracts;
using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.PhoneBooks.QueryHandlers;

public class GetPhoneBookByIdRequestHandler(
    IPhoneBookRepository phoneBookRepository,
    IUserContext userContext
) : IBaseQueryHandler<GetPhoneBookByIdRequest, GetPhoneBookByIdResponse>
{
    public async Task<GetPhoneBookByIdResponse> Handle(GetPhoneBookByIdRequest request,
        CancellationToken cancellationToken)
    {
        var phoneBook = await phoneBookRepository.FindAsync
        (
            book => book.Id == request.Id && book.UserId == userContext.UserId,
            cancellationToken
        );

        return phoneBook.ToGetPhoneBookByIdResponse();
    }
}