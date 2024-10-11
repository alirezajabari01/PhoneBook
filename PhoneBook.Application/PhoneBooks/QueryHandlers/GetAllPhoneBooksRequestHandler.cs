using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Contract.PhoneBooks.Requests;
using PhoneBook.Application.UserFilters;
using PhoneBook.Domain.PhoneBooks.Contracts;
using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.PhoneBooks.QueryHandlers;

public class GetAllPhoneBooksRequestHandler(
    IPhoneBookRepository phoneBookRepository,
    IUserContext userContext
)
    : IBaseQueryHandler<GetAllPhoneBooksRequest, List<GetAllPhoneBooksResponse>>
{
    public async Task<List<GetAllPhoneBooksResponse>> Handle(GetAllPhoneBooksRequest request,
        CancellationToken cancellationToken)
    {
        var phoneBooks = await phoneBookRepository
            .GetQueryable()
            .Where(book => book.UserId == userContext.UserId)
            .ToListAsync(cancellationToken);


        return phoneBooks.ToGetAllPhoneBooksResponse();
    }
}