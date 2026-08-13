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
        builder.ToTable("Product");
        
        // Primary key is ID
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .UseIdentityColumn(); // Unique Identity (1,1)
        
        // PublicId
        builder.HasIndex(p => p.PublicId)
            .IsUnique();
        builder.Property(p => p.PublicId)
            .ValueGeneratedNever()
            .IsRequired();

        // Name
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(250);

        // 1 Category - Many Products
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Avoid deleting product when deleting category
        
        // 1 Brand - Many Products
        builder.HasOne(p => p.Brands)
            .WithMany(b => b.Products)
            .HasForeignKey(b => b.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // 1 Product - Many Variants
        builder.HasMany(p => p.Variants)
            .WithOne(v => v.Product)
            .HasForeignKey(v => v.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}