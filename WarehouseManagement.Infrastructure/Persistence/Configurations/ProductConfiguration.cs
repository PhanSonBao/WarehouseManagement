using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.Persistence.Configurations;

// Implement IEntityTypeConfiguration<Product>
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    // Fluent API
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Table Name
        builder.ToTable("Products");
        
        // Primary key is Id
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever(); // Already Generate Guid in domain
        
        // SKU
        builder.Property(p => p.SKU)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(p => p.SKU)
            .IsUnique(); // Unique Index

        // Name
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        // Barcode
        builder.Property(p => p.BarCode)
            .HasMaxLength(100);
        builder.HasIndex(p => p.BarCode); // Để lookup nhanh khi scan
        
        // CostPrice và SalePrice: kiểu long
        builder.Property(p => p.CostPrice);

        // Khai báo quan hệ với Category (HasOne/WithMany)
        // Khai báo quan hệ với Brand nếu có
    }
}