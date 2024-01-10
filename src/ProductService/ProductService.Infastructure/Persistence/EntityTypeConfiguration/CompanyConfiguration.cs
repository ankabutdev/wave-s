using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.Entities;

namespace ProductService.Infastructure.Persistence.EntityTypeConfiguration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .UseIdentityColumn()
            .HasColumnName("id");

        entity.Property(e => e.CompanyPhoneNumber)
            .HasMaxLength(13);

        entity.Property(e => e.Email)
            .HasMaxLength(256);

        entity.HasMany(x => x.Products)
            .WithOne(x => x.Company);
    }
}
