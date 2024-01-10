using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.Entities;

namespace ProductService.Infastructure.Persistence.EntityTypeConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.Id).HasName("products_pkey");

        builder.ToTable("products");

        builder.Property(e => e.Id)
            .UseIdentityColumn()
            .HasColumnName("id");

        builder.Property(e => e.Backlight).HasColumnName("backlight");
        builder.Property(e => e.Buttons).HasColumnName("buttons");
        builder.Property(e => e.CategoryId).HasColumnName("category_id");
        builder.Property(e => e.CompanyId).HasColumnName("company_id");
        builder.Property(e => e.CreatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");

        builder.Property(e => e.Description).HasColumnName("description");
        builder.Property(e => e.Foam).HasColumnName("foam");
        builder.Property(e => e.Frame).HasColumnName("frame");
        builder.Property(e => e.ImagePaths).HasColumnName("image_paths");
        builder.Property(e => e.Mounted).HasColumnName("mounted");
        builder.Property(e => e.Mum).HasColumnName("mum");
        builder.Property(e => e.Name).HasColumnName("name");
        builder.Property(e => e.Price).HasColumnName("price");
        builder.Property(e => e.Screen).HasColumnName("screen");
        builder.Property(e => e.Smartpause).HasColumnName("smartpause");
        builder.Property(e => e.Turbopressure).HasColumnName("turbopressure");
        builder.Property(e => e.Type).HasColumnName("type");
        builder.Property(e => e.UpdatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_at");

        builder.Property(e => e.Weight).HasColumnName("weight");

        builder.HasOne(d => d.Category).WithMany(p => p.Products)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("products_category_id_fkey");

        builder.HasOne(d => d.Company).WithMany(p => p.Products)
            .HasForeignKey(d => d.CompanyId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("products_company_id_fkey");
    }
}
