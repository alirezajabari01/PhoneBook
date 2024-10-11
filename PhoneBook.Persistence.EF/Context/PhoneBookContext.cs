using System.Linq.Expressions;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assembly = typeof(IEntity).Assembly;
        var efAssembly = typeof(IPersistenceEfLayerMarker).Assembly;

        FilterDeletedRecords(modelBuilder);

        RegisterEntities(modelBuilder, assembly);

        RegisterEntityTypeConfiguration(modelBuilder, efAssembly);
    }

    private static void FilterDeletedRecords(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // Check if the entity has the DeletedAt property
            var deletedAtProperty = entityType.FindProperty("DeletedDate");
            if (deletedAtProperty != null)
            {
                // Configure the query filter
                var parameter = Expression.Parameter(entityType.ClrType);
                var property = Expression.Property(parameter, "DeletedDate");
                var filterExpression = Expression.Equal(property, Expression.Constant(null));

                var lambdaExpression = Expression.Lambda(filterExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambdaExpression);
            }
        }
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