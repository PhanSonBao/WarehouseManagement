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
        builder.ToTable("InventoryItems");

        // Primary key
        builder.HasKey(i => i.Id);

        // Mỗi sản phẩm chỉ có 1 dòng tồn kho tại 1 kho duy nhất
        builder.HasIndex(i => i.ProductVariantId)
            .IsUnique();
        builder.HasIndex(i => i.WarehouseId)
            .IsUnique();

        // Concurrency: Ngăn 2 request cùng lúc sửa tồn
        builder.Property(i => i.RowVersion)
            .IsRowVersion();
    }
}