using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Application.Abstractions;

public interface IAppDbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Product> Products { get; set; }

    ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
