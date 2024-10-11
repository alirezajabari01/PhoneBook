using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Users;
using PhoneBook.Domain.Users.Contracts;
using PhoneBook.Persistence.EF.Context;

namespace PhoneBook.Persistence.EF.Users;

public class UserRepository(PhoneBookContext phoneBookContext) : IUserRepository
{
    public async Task<bool> IsExistAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken)
        => await phoneBookContext.Set<User>().AnyAsync(predicate, cancellationToken);

    public async Task AddAsync(User user, CancellationToken cancellationToken)
        => await phoneBookContext.AddAsync(user, cancellationToken);


    public void Delete(User user)
        => phoneBookContext.Remove(user);

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
        => await phoneBookContext.SaveChangesAsync(cancellationToken);

    public void Update(User user, CancellationToken cancellationToken)
        => phoneBookContext.Set<User>().Update(user);

    public async Task<User?> GetByIdAsync(long id, CancellationToken cancellationToken)
        => await phoneBookContext.FindAsync<User>(id, cancellationToken);

    public async Task<User?> SingleOrDefaultAsync(Expression<Func<User, bool>> predicate,
        CancellationToken cancellationToken)
        => await phoneBookContext.Set<User>()
               .SingleOrDefaultAsync(predicate, cancellationToken)
           ?? throw new NullReferenceException();
}