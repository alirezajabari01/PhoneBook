using PhoneBook.Domain.Abstractions;

namespace PhoneBook.Domain.Users.Contracts;

public interface IUserNameDuplicateChecker : IScopeLifeTime
{
    Task<bool> IsUserNameDuplicate(string userName,CancellationToken cancellationToken);
}