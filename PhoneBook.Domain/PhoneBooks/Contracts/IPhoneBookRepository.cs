using System.Linq.Expressions;
using PhoneBook.Domain.Abstractions;

namespace PhoneBook.Domain.PhoneBooks.Contracts;

public interface IPhoneBookRepository : IScopeLifeTime
{
    public bool IsExist(Expression<Func<PhoneBook, bool>> predicate);
    public void Add(PhoneBook user);
    public void Delete(PhoneBook user);
    public void Save();
    public void Update(PhoneBook user);
    public PhoneBook? GetById(long id);
    public PhoneBook? Find(Expression<Func<PhoneBook, bool>> predicate);
}