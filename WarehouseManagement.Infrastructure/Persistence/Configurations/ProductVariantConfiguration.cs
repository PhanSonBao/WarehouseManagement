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
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.HasIndex(p => p.Sku)
            .IsUnique(); // Unique Index

        // Barcode
        builder.Property(p => p.Barcode)
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.HasIndex(p => p.Barcode); // Quick lookup when scanning

        // FK
        builder.HasOne(v => v.Product)
            .WithMany(v => v.Variants)
            .HasForeignKey(v => v.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(v => v.Unit)
            .WithMany(v => v.Variants)
            .HasForeignKey(v => v.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}