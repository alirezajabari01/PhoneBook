using PhoneBook.Domain.PhoneBooks.Contracts;

namespace PhoneBook.Domain.Service.PhoneBooks;

public class PhoneNumberDuplicateChecker( IPhoneBookRepository repository):IPhoneNumberDuplicateChecker
{
    public bool IsPhoneNumberDuplicated(string phoneNumber)
        => repository.IsExist(book => book.PhoneNumber.Value == phoneNumber);
}