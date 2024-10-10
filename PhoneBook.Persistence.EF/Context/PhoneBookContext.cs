using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneBook.Domain.Abstractions;
using PhoneBook.Domain.Users;
using PhoneBook.Persistence.EF.PhoneBooks;
using PhoneBook.Persistence.EF.Users;

namespace PhoneBook.Persistence.EF.Context;

public class PhoneBookContext : DbContext
{
    public PhoneBookContext(DbContextOptions<PhoneBookContext> option) : base(option)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Domain.PhoneBooks.PhoneBook> PhoneBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.EnableSensitiveDataLogging()
            .LogTo(Console.Error.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assembly = typeof(IEntity).Assembly;
        var efAssembly = typeof(IPersistenceEfLayerMarker).Assembly;

        RegisterEntities(modelBuilder, assembly);

        RegisterEntityTypeConfiguration(modelBuilder, efAssembly);
    }

    private static void RegisterEntities(ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
            .Where(c => c.IsClass && !c.IsAbstract &&
                        c.IsPublic && typeof(IEntity).IsAssignableFrom(c));

        foreach (var type in types)
        {
            modelBuilder.Entity(type);
        }
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
}