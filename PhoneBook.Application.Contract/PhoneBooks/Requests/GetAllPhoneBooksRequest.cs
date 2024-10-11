using MediatR;
using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.Contract.PhoneBooks.Requests;

public record GetAllPhoneBooksRequest : IBaseQuery<List<GetAllPhoneBooksResponse>>;

public record GetAllPhoneBooksResponse(
    long Id,
    string UserName,
    string PhoneNumber
);

public static class GetAllPhoneBooksResponseMapper
{
    public static List<GetAllPhoneBooksResponse> ToGetAllPhoneBooksResponse
        (this List<Domain.PhoneBooks.PhoneBook> phoneBooks)
        => phoneBooks.Select
        (
            book =>
                new GetAllPhoneBooksResponse
                (
                    book.Id,
                    book.UserName.Value,
                    book.PhoneNumber.Value
                )
        ).ToList();
}