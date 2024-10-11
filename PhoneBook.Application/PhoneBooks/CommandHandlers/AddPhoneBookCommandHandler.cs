using PhoneBook.Application.Contract.PhoneBooks.Commands;
using PhoneBook.Application.UserFilters;
using PhoneBook.Domain.PhoneBooks.Contracts;
using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.PhoneBooks.CommandHandlers;

public class AddPhoneBookCommandHandler(
    IPhoneBookRepository phoneBookRepository,
    IPhoneNumberDuplicateChecker phoneNumberDuplicateChecker,
    IPhoneBookUserNameDuplicateChecker phoneBookUserNameDuplicateChecker,
    IUserContext userContext
) : IBaseCommandHandler<AddPhoneBookCommand>
{
    public async Task Handle(AddPhoneBookCommand request, CancellationToken cancellationToken)
    {
        var phoneBook = new Domain.PhoneBooks.PhoneBook
        (
            request.UserName,
            request.PhoneNumber,
            userContext.UserId,
            phoneNumberDuplicateChecker,
            phoneBookUserNameDuplicateChecker
        );

        phoneBookRepository.Add(phoneBook);
        await phoneBookRepository.SaveChangesAsync(cancellationToken);
    }
}