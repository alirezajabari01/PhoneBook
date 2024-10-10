using PhoneBook.Domain.PhoneBooks.Contracts;

namespace PhoneBook.Domain.Service.PhoneBooks;

public class PhoneBookUserNameDuplicateChecker(IPhoneBookRepository phoneBookRepository)
    : IPhoneBookUserNameDuplicateChecker
{
    public bool IsPhoneBookUserNameDuplicated(string userName)
        => phoneBookRepository.IsExist(book => book.UserName.Value == userName);
}