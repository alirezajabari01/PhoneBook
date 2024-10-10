using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.Users;

namespace PhoneBook.Persistence.EF.PhoneBooks;

public class PhoneBookEntityTypeConfigurations : IEntityTypeConfiguration<Domain.PhoneBooks.PhoneBook>
{
    public void Configure(EntityTypeBuilder<Domain.PhoneBooks.PhoneBook> builder)
    {
        builder.HasKey(book => book.Id);
        builder.OwnsOne
        (
            phoneBook => phoneBook.UserName, buildAction =>
            {
                buildAction.Property(propertyExpression => propertyExpression.Value)
                    .IsRequired()
                    .HasColumnType(SqlDbType.NVarChar.ToString())
                    .HasMaxLength(32)
                    .HasColumnName(nameof(Domain.PhoneBooks.PhoneBook.UserName));
            }
        );
        builder.OwnsOne
        (
            phoneBook => phoneBook.PhoneNumber, buildAction =>
            {
                buildAction.Property(propertyExpression => propertyExpression.Value)
                    .IsRequired()
                    .HasColumnType(SqlDbType.NVarChar.ToString())
                    .HasMaxLength(11)
                    .HasColumnName(nameof(Domain.PhoneBooks.PhoneBook.PhoneNumber));
            }
        );
    }
}