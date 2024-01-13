using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;

namespace OrderService.Application.Abstractions;

public interface IAppDbContext
{
    public DbSet<Order> Orders { get; set; }

    ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
