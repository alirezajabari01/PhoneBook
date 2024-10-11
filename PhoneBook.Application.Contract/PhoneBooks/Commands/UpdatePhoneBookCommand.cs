using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.Contract.PhoneBooks.Commands;

public record UpdatePhoneBookCommand(long Id, string UserName, string PhoneNumber)
    : IBaseCommand;

public static class UpdatePhoneBookCommandMapper
{
    public static Domain.PhoneBooks.PhoneBook ToPhoneBook
        (this UpdatePhoneBookCommand command,Domain.PhoneBooks.PhoneBook phoneBook)
    {
        phoneBook.PhoneNumber.Value = command.PhoneNumber;
        phoneBook.UserName.Value = command.UserName;

        return phoneBook;
    }
}