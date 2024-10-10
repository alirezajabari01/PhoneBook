using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.Users;

namespace PhoneBook.Persistence.EF.Users;

public class UsersEntityTypeConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);
        builder.OwnsOne
        (
            user => user.UserName, buildAction =>
            {
                buildAction.Property(propertyExpression => propertyExpression.Value)
                    .IsRequired()
                    .HasColumnType(SqlDbType.NVarChar.ToString())
                    .HasMaxLength(32)
                    .HasColumnName(nameof(User.UserName));
            }
        );
        builder.OwnsOne
        (
            user => user.Password, buildAction =>
            {
                buildAction.Property(propertyExpression => propertyExpression.Value)
                    .IsRequired()
                    .HasColumnType(SqlDbType.NVarChar.ToString())
                    .HasMaxLength(150)
                    .HasColumnName(nameof(User.Password));
            }
        );
    }
}