using System.Linq.Expressions;
using PhoneBook.Domain.Abstractions;

namespace PhoneBook.Domain.PhoneBooks.Contracts;

public interface IPhoneBookRepository : IScopeLifeTime
{
    public bool IsExist(Expression<Func<PhoneBook, bool>> predicate);
    public void Add(PhoneBook phoneBook);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
    public void Update(PhoneBook phoneBook);
    public Task<PhoneBook?> FindAsync(Expression<Func<PhoneBook, bool>> predicate,CancellationToken cancellationToken);
    public IQueryable<PhoneBook> GetQueryable();
}