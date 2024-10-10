using PhoneBook.Domain.Users.Contracts;

namespace PhoneBook.Domain.Service.Users;

public class CoachDuplicateChecker(IUserRepository _repository) : IUserNameDuplicateChecker
{
    public bool IsUserNameDuplicate(string userName)
        => _repository.IsExist
        (
            user => user.UserName.Value == userName
        );
}