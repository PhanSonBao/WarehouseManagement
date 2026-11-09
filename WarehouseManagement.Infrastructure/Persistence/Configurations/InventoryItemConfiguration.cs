using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.Persistence.Configurations;

// Implement IEntityTypeConfiguration<Inventory>
public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    // Fluent API
    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        // Table name
        builder.ToTable("InventoryItem");

        // Primary key
        builder.HasKey(i => i.Id);
        builder.Property(i => i.PublicId)
            .IsRequired();

        builder.Property(i => i.ProductVariantId)
            .IsRequired();
        
        // 1 unique stock row for 1 (variant, warehouse)
        builder.HasIndex(i => new 
            { i.ProductVariantId, i.WarehouseId }) // Composite Index
            .IsUnique();

        // Concurrency: Prevent 2 request modified data simultaneously
        builder.Property(i => i.RowVersion)
            .IsRowVersion();
    }
}