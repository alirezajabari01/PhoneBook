using PhoneBook.Application.Contract.PhoneBooks.Commands;
using PhoneBook.Application.UserFilters;
using PhoneBook.Domain.PhoneBooks.Contracts;
using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.PhoneBooks.CommandHandlers;

public class UpdatePhoneBookCommandHandler(
    IPhoneBookRepository phoneBookRepository,
    IUserContext userContext
) : IBaseCommandHandler<UpdatePhoneBookCommand>
{
    public async Task Handle(UpdatePhoneBookCommand request, CancellationToken cancellationToken)
    {
        var phoneBook = await phoneBookRepository.FindAsync
            (book => book.UserId == userContext.UserId && book.Id == request.Id, cancellationToken);

        request.ToPhoneBook(phoneBook);

        phoneBookRepository.Update(phoneBook);
        await phoneBookRepository.SaveChangesAsync(cancellationToken);
    }
}