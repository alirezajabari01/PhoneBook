namespace PhoneBook.Domain.Abstractions;

public class BaseEntity<TKey> : IEntity
{
    public TKey Key { get; set; }
    public DateTime DeletedDate { get; set; }
    public DateTime CreatedDate { get; set; }
}