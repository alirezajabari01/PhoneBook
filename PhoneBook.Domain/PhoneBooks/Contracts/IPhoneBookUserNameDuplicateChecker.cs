using PhoneBook.Domain.Abstractions;

namespace PhoneBook.Domain.PhoneBooks.Contracts;

public interface IPhoneBookUserNameDuplicateChecker : IScopeLifeTime
{
    bool IsPhoneBookUserNameDuplicated(string userName);
}