using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.PhoneBooks.Contracts;
using PhoneBook.Persistence.EF.Context;

namespace PhoneBook.Persistence.EF.PhoneBooks;

public class PhoneBookRepository(PhoneBookContext phoneBookContext) : IPhoneBookRepository
{
    public bool IsExist(Expression<Func<Domain.PhoneBooks.PhoneBook, bool>> predicate)
        => phoneBookContext.PhoneBooks.Any(predicate);
    public void Add(Domain.PhoneBooks.PhoneBook phoneBook)
        => phoneBookContext.PhoneBooks.Add(phoneBook);
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
        => await phoneBookContext.SaveChangesAsync(cancellationToken);
    public void Update(Domain.PhoneBooks.PhoneBook phoneBook)
        => phoneBookContext.PhoneBooks.Update(phoneBook);
    public async Task<Domain.PhoneBooks.PhoneBook?> FindAsync
    (Expression<Func<Domain.PhoneBooks.PhoneBook, bool>> predicate
        , CancellationToken cancellationToken)
        => await phoneBookContext.PhoneBooks.SingleOrDefaultAsync(predicate, cancellationToken);
    public IQueryable<Domain.PhoneBooks.PhoneBook> GetQueryable()
        => phoneBookContext.PhoneBooks;
}