using PhoneBook.Domain.Abstractions;

namespace PhoneBook.Domain.PhoneBooks.Contracts;

public interface IPhoneNumberDuplicateChecker : IScopeLifeTime
{
    bool IsPhoneNumberDuplicated(string phoneNumber);
}