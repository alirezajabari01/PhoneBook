using Autofac;
using MediatR;
using PhoneBook.Application;
using PhoneBook.Application.Contract;
using PhoneBook.Domain;
using PhoneBook.Domain.Abstractions;
using PhoneBook.Domain.Service.Users;
using PhoneBook.Domain.Users.Contracts;
using PhoneBook.MediatR;
using PhoneBook.MediatR.Mediator;
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
        var mediatRServiceAssembly = typeof(IMediatRLayerMarker).Assembly;

        builder.RegisterAssemblyTypes
            (
                applicationAssembly,
                persistenceAssembly,
                applicationContractAssembly,
                domainAssembly,
                domainServiceAssembly,
                mediatRServiceAssembly
            )
            .AssignableTo<IScopeLifeTime>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(applicationAssembly)
            .AsClosedTypesOf(typeof(IBaseCommandHandler<>))  // Register all IRequestHandler implementations
            .InstancePerLifetimeScope();
        
        builder.RegisterType<UserNameDuplicateChecker>()
            .As<IUserNameDuplicateChecker>()
            .InstancePerLifetimeScope(); // or another appropriate lifetime

        base.Load(builder);
    }
}