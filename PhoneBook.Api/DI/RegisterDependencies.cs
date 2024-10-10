using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Abstractions;
using PhoneBook.Persistence.EF.Context;

namespace PhoneBook.Api.DI;

public static class RegisterDependencies
{
    public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var dbContext = scope.ServiceProvider.GetService<PhoneBookContext>(); 
        
        dbContext.Database.Migrate();

        var dataInitializers = scope.ServiceProvider.GetServices<IDataInitializer>().OrderBy(i => i.Order);
        foreach (var dataInitializer in dataInitializers)
            dataInitializer.InitializeData();

        return app;
    }
    public interface IDataInitializer : IScopeLifeTime
    {
        public int Order { get; }

        public void InitializeData();
    }
    public static WebApplicationBuilder RegisterAutoFac
        (this WebApplicationBuilder builder, ConfigureHostBuilder hostBuilder)
    {
        hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        hostBuilder.ConfigureContainer<ContainerBuilder>(
            containerBuilder => containerBuilder.RegisterModule(new AutofacModule()));

        return builder;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection service)
        => service.RegisterDatabase();
}