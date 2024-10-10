using System.Linq.Expressions;
using PhoneBook.Domain.Users;
using PhoneBook.Domain.Users.Contracts;

namespace PhoneBook.Persistence.EF.Users;

public class UserRepository:IUserRepository
{
    public bool IsExist(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Add(User user)
    {
        throw new NotImplementedException();
    }

    public void Delete(User user)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }

    public User? GetById(long id)
    {
        throw new NotImplementedException();
    }

    public User? Find(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}