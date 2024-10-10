using System.Linq.Expressions;
using PhoneBook.Domain.PhoneBooks.Contracts;

namespace PhoneBook.Persistence.EF.PhoneBooks;

public class PhoneBookRepository : IPhoneBookRepository
{
    public bool IsExist(Expression<Func<Domain.PhoneBooks.PhoneBook, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Add(Domain.PhoneBooks.PhoneBook user)
    {
        throw new NotImplementedException();
    }

    public void Delete(Domain.PhoneBooks.PhoneBook user)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public void Update(Domain.PhoneBooks.PhoneBook user)
    {
        throw new NotImplementedException();
    }

    public Domain.PhoneBooks.PhoneBook? GetById(long id)
    {
        throw new NotImplementedException();
    }

    public Domain.PhoneBooks.PhoneBook? Find(Expression<Func<Domain.PhoneBooks.PhoneBook, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}