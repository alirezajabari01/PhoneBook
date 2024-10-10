using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Domain.Abstractions;

public abstract class BaseEntity<TKey> : IEntity
{
    [Key]
    public TKey Id { get; set; }
    public DateTime DeletedDate { get; set; }
    public DateTime CreatedDate { get; set; }
}