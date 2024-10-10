using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneBook.Persistence.EF.Context;

public static class DependencyInjection
{
    public static IServiceCollection RegisterDatabase(this IServiceCollection service)
    {
        return service.AddDbContext<PhoneBookContext>
        (
            options =>
                 options.UseSqlServer
                 (
                     "Data Source=DESKTOP-G79AH4U;Initial Catalog=PhoneBook;Persist Security Info=True;User ID=sa;Password=Kiau@123%J;TrustServerCertificate=True"
                 )
         );
 
         // return service.AddDbContext<PhoneBookContext>
         // (
         //     option =>
         //         option.UseInMemoryDatabase("PhoneBook")
         // );
     }
 }