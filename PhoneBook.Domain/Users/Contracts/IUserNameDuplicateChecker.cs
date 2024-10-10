using PhoneBook.Domain.Abstractions;

namespace PhoneBook.Domain.Users.Contracts;

public interface IUserNameDuplicateChecker : IScopeLifeTime
{
    bool IsUserNameDuplicate(string userName);
}