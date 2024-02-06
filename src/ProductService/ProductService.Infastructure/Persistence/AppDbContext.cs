using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;
using ProductService.Domain.Entities;
using System.Reflection;

namespace ProductService.Infastructure.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.Migrate();
        /*
         var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        try
        {
            if (databaseCreator is null)
            {
                throw new Exception("Database Not Found!");
            }

            if (!databaseCreator.CanConnect())
                databaseCreator.CreateAsync();

            if (!databaseCreator.HasTables())
                databaseCreator.CreateTablesAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
         */
    }

    public AppDbContext()
    {

    }

    async ValueTask<int> IAppDbContext.SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
