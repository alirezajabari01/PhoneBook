using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.Contract.PhoneBooks.Requests;

public record GetPhoneBookByIdRequest(long Id) : IBaseQuery<GetPhoneBookByIdResponse>;

public record GetPhoneBookByIdResponse(
    long Id,
    string UserName,
    string PhoneNumber
);

public static class GetPhoneBookByIdResponseMapper
{
    public static GetPhoneBookByIdResponse ToGetPhoneBookByIdResponse
        (this Domain.PhoneBooks.PhoneBook phoneBook)
        => new 
        (
            phoneBook.Id,
            phoneBook.UserName.Value,
            phoneBook.PhoneNumber.Value
        );
}