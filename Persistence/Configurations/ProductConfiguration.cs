using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion(
            id => id.Value,
            value => ProductId.Of(value)
        );

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

        builder.Property(p => p.Description).HasMaxLength(3000);

        builder.OwnsOne(p => p.Price, pp =>
        {
            pp.Property(p => p.Price).IsRequired();
            pp.Property(p => p.Currency).IsRequired();
        });

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        builder.Property(p => p.StockQuantity).IsRequired();
    }
}