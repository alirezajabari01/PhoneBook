using Autofac;
using Autofac.Extensions.DependencyInjection;
using PhoneBook.Persistence.EF.Context;

namespace PhoneBook.Api.DI;

public static class RegisterDependencies
{
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