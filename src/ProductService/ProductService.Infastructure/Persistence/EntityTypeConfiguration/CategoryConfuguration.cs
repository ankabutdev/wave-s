using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.Entities;

namespace ProductService.Infastructure.Persistence.EntityTypeConfiguration;

public class CategoryConfuguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.HasKey(e => e.Id).HasName("categories_pkey");

        entity.ToTable("categories");

        entity.Property(e => e.Id)
            .UseIdentityColumn()
            .HasColumnName("id");

        entity.Property(e => e.CreatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.Description).HasColumnName("description");
        entity.Property(e => e.Name).HasColumnName("name");
        entity.Property(e => e.UpdatedAt)

            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_at");
    }
}
