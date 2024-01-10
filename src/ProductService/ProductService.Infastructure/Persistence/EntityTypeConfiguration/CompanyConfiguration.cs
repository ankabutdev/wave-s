using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.Entities;

namespace ProductService.Infastructure.Persistence.EntityTypeConfiguration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> entity)
    {
        entity.HasKey(e => e.Id).HasName("companies_pkey");

        entity.ToTable("companies");

        entity.Property(e => e.Id)
            .UseIdentityColumn()
            .HasColumnName("id");

        entity.Property(e => e.CompanyPhoneNumber)
            .HasMaxLength(13)
            .HasColumnName("company_phone_number");

        entity.Property(e => e.CreatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.Description).HasColumnName("description");
        entity.Property(e => e.Email)
            .HasMaxLength(256)
            .HasColumnName("email");

        entity.Property(e => e.Name).HasColumnName("name");
        entity.Property(e => e.UpdatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_at");
    }
}
