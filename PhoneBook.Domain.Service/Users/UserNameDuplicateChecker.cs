using PhoneBook.Domain.Users.Contracts;

namespace PhoneBook.Domain.Service.Users;

public class UserNameDuplicateChecker(IUserRepository _repository) : IUserNameDuplicateChecker
{
    public Task<bool> IsUserNameDuplicate(string userName, CancellationToken cancellationToken)
        => _repository.IsExistAsync
        (
            user => user.UserName.Value == userName,
            cancellationToken
        );
}