using System.Linq.Expressions;
using PhoneBook.Domain.Abstractions;

namespace PhoneBook.Domain.Users.Contracts;

public interface IUserRepository : IRepository, IScopeLifeTime
{
    public Task<bool> IsExistAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken);
    public Task AddAsync(User user, CancellationToken cancellationToken);
    public void Delete(User user);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
    public void Update(User user, CancellationToken cancellationToken);
    public Task<User?> GetByIdAsync(long id, CancellationToken cancellationToken);
    public Task<User?> SingleOrDefaultAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken);
}