using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace PhoneBook.Persistence.EF.Context
{
    public class PhoneBookContextFactory : IDesignTimeDbContextFactory<PhoneBookContext>
    {
        public PhoneBookContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhoneBookContext>();

            // Directly specifying the connection string here
            string connectionString = "Data Source=DESKTOP-G79AH4U;Initial Catalog=PhoneBook;Persist Security Info=True;User ID=sa;Password=Kiau@123%J;TrustServerCertificate=True";

            optionsBuilder.UseSqlServer(connectionString);

            return new PhoneBookContext(optionsBuilder.Options);
        }
    }
}