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
            .UseIdentityColumn(); // Unique Identity (1,1)
        
        // PublicId
        builder.HasIndex(p => p.PublicId)
            .IsUnique();
        builder.Property(p => p.PublicId)
            .ValueGeneratedNever()
            .IsRequired();
        
        // SKU
        builder.Property(p => p.Sku)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(p => p.Sku)
            .IsUnique(); // Unique Index

        // Name
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        // Barcode
        builder.Property(p => p.Barcode)
            .HasMaxLength(100);
        builder.HasIndex(p => p.Barcode); // Để lookup nhanh khi scan
        
        // CostPrice và SalePrice: kiểu decimal
        builder.Property(p => p.CostPrice)
            .HasPrecision(18, 0);
        builder.Property(p => p.SalePrice)
            .HasPrecision(18, 0);

        // 1 Category - Many Products
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Tránh việc xóa category thì xóa product
        
        // 1 Brand - Many Products
        builder.HasOne(p => p.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(b => b.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}