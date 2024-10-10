using Autofac;
using PhoneBook.Application;
using PhoneBook.Application.Contract;
using PhoneBook.Domain;
using PhoneBook.Domain.Abstractions;
using PhoneBook.Persistence.EF;
using Module = Autofac.Module;

namespace PhoneBook.Api.DI;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var applicationAssembly = typeof(IApplicationLayerMarker).Assembly;
        var persistenceAssembly = typeof(IPersistenceEfLayerMarker).Assembly;
        var applicationContractAssembly = typeof(IApplicationContractLayerMarker).Assembly;
        var domainAssembly = typeof(IDomainLayerMarker).Assembly;
        var domainServiceAssembly = typeof(IDomainLayerMarker).Assembly;

        builder.RegisterAssemblyTypes
            (
                applicationAssembly,
                persistenceAssembly,
                applicationContractAssembly,
                domainAssembly,
                domainServiceAssembly
            )
            .AssignableTo<IScopeLifeTime>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        base.Load(builder);
    }
}