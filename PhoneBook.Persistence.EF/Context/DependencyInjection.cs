using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneBook.Persistence.EF.Context;

public static class DependencyInjection
{
    public static IServiceCollection RegisterDatabase(this IServiceCollection service)
    {
        return service.AddDbContext<PhoneBookContext>
        (
            options => options.UseNpgsql
                ("User ID=postgres;Password=fwoWct6kLuqiBR9LKjqNsBEdjG7Wc1Vx;Server=70f31966-0447-494e-883d-449fcebed459.hsvc.ir;Port=30437;Database=PhoneBook;")
        );
    }
}