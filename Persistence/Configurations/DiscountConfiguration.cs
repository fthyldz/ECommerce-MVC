using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .HasConversion(
                id => id.Value,
                value => DiscountId.Of(value)
            );

        builder.HasOne(d => d.Product)
            .WithMany()
            .HasForeignKey(d => d.ProductId);

        builder.HasOne(d => d.Role)
            .WithMany()
            .HasForeignKey(d => d.RoleId);
    }
}