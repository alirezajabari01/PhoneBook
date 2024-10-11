using PhoneBook.Application.Contract.PhoneBooks.Commands;
using PhoneBook.Application.UserFilters;
using PhoneBook.Domain.PhoneBooks.Contracts;
using PhoneBook.MediatR.Mediator;

namespace PhoneBook.Application.PhoneBooks.CommandHandlers;

public class DeletePhoneBookCommandHandler(
    IPhoneBookRepository phoneBookRepository,
    IUserContext userContext
) : IBaseCommandHandler<DeletePhoneBookCommand>
{
    public async Task Handle(DeletePhoneBookCommand request, CancellationToken cancellationToken)
    {
        var phoneBook = await phoneBookRepository.FindAsync
        (
            book => book.UserId == userContext.UserId && book.Id == request.Id,
            cancellationToken
        );

        phoneBook.DeletedDate = DateTime.Now;

        phoneBookRepository.Update(phoneBook);

        await phoneBookRepository.SaveChangesAsync(cancellationToken);
    }
}