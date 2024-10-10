using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Abstractions;

namespace PhoneBook.Persistence.EF.Context;

public class PhoneBookContext : DbContext
{
    public PhoneBookContext(DbContextOptions<PhoneBookContext> option) : base(option)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assembly = typeof(IEntity).Assembly;
        RegisterEntities(modelBuilder, assembly);
        RegisterEntityTypeConfiguration(modelBuilder, assembly);
    }
    private void RegisterEntityTypeConfiguration(ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        MethodInfo applyGenericMethod = typeof(ModelBuilder).GetMethods()
            .First(m => m.Name == nameof(ModelBuilder.ApplyConfiguration));

        IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
            .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic);

        foreach (Type type in types)
        {
            foreach (Type iface in type.GetInterfaces())
            {
                if (iface.IsConstructedGenericType &&
                    iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                {
                    MethodInfo applyConcreteMethod =
                        applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                    applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                }
            }
        }
    }
    private void RegisterEntities(ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        IEnumerable<Type> types = assemblies
            .SelectMany(assembly => assembly.GetExportedTypes())
            .Where
            (
                type => !type.IsAbstract &&
                        !type.IsInterface &&
                        type.IsClass &&
                        type.IsPublic &&
                        typeof(IEntity).IsAssignableFrom(type)
            );

        foreach (var type in types) modelBuilder.Entity(type);
    }
}