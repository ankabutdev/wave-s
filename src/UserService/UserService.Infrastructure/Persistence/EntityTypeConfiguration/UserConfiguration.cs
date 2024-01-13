using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.Entities.Users;

namespace OrderService.Infrastructure.Persistence.EntityTypeConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(256);

        builder.Property(x => x.FullName)
            .HasMaxLength(256);
    }
}
