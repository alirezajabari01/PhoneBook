using PhoneBook.Domain.Abstractions;

namespace PhoneBook.Application.UserFilters;

public interface IUserContext : IScopeLifeTime
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
}