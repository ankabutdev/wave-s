using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.Entities;

namespace ProductService.Infastructure.Persistence.EntityTypeConfiguration;

public class CategoryConfuguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .UseIdentityColumn();

        entity.HasMany(x => x.Products)
            .WithOne(x => x.Category);
    }
}
