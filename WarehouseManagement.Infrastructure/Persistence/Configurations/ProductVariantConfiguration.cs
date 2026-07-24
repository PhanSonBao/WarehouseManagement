using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.Persistence.Configurations;

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        // Table Name
        builder.ToTable("ProductVariant");

        // SKU
        builder.Property(p => p.Sku)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(p => p.Sku)
            .IsUnique(); // Unique Index

        // Barcode
        builder.Property(p => p.Barcode)
            .HasMaxLength(100);
        builder.HasIndex(p => p.Barcode); // Quick lookup when scanning
    }
}