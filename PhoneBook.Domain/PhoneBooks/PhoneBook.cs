using PhoneBook.Domain.Abstractions;
using PhoneBook.Domain.PhoneBooks.Contracts;
using PhoneBook.Domain.PhoneBooks.Exceptions;
using PhoneBook.Domain.PhoneBooks.ValueObjects;
using PhoneBook.Domain.Users;
using PhoneBook.Domain.Users.ValueObjects;

namespace PhoneBook.Domain.PhoneBooks;

public class PhoneBook : BaseEntity<long>
{
    private PhoneBook()
    {
    }

    public PhoneBook(string userName, string phoneNumber, Guid userId
        , IPhoneNumberDuplicateChecker phoneNumberDuplicateChecker,
        IPhoneBookUserNameDuplicateChecker phoneBookUserNameDuplicateChecker)
    {
        Validate
        (
            phoneNumberDuplicateChecker,
            phoneBookUserNameDuplicateChecker,
            userName,
            phoneNumber
        );
        UserId = userId;
        PhoneNumber = new PhoneNumber(phoneNumber);
        UserName = new UserName(userName);
    }

    public UserName UserName { get; set; }
    public PhoneNumber PhoneNumber { get; set; }

    public Guid UserId { get; set; }


    public User User { get; set; }

    private void Validate
    (
        IPhoneNumberDuplicateChecker phoneNumberDuplicateChecker,
        IPhoneBookUserNameDuplicateChecker phoneBookUserNameDuplicateChecker,
        string userName, string phoneNumber
    )
    {
        if (phoneBookUserNameDuplicateChecker.IsPhoneBookUserNameDuplicated(userName))
            throw new UserNameDuplicateException();

        if (phoneNumberDuplicateChecker.IsPhoneNumberDuplicated(phoneNumber))
            throw new PhoneNumberDuplicateException();
    }
}