using PhoneBook.Domain.Abstractions;
using PhoneBook.Domain.PhoneBooks.ValueObjects;
using PhoneBook.Domain.Users;
using PhoneBook.Domain.Users.ValueObjects;

namespace PhoneBook.Domain.PhoneBooks;

public class PhoneBook : BaseEntity<long>
{
    private PhoneBook(string userName, string phoneNumber, Guid userId)
    {
        UserId = userId;
        PhoneNumber = new PhoneNumber(phoneNumber);
        UserName = new UserName(userName);
    }
    
    public UserName UserName { get; set; }
    public PhoneNumber PhoneNumber { get; set; }

    public Guid UserId { get; set; }


    public User User { get; set; }
    
}