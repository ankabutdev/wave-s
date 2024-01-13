using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities.Users;

namespace UserService.Application.Abstractions;

public interface IAppDbContext
{
    public DbSet<User> Users { get; set; }

    ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
