using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhoneBook.Persistence.EF.PhoneBooks;

public class PhoneBookEntityTypeConfigurations : IEntityTypeConfiguration<Domain.PhoneBooks.PhoneBook>
{
    public void Configure(EntityTypeBuilder<Domain.PhoneBooks.PhoneBook> builder)
    {
        
    }
}