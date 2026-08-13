using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.Persistence.Configurations;

public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
        // Table name
        builder.ToTable("StockMovement");
        
        // PK
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id)
            .UseIdentityColumn();

        builder.Property(i => i.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(i => i.Quantity);
        
        builder.Property(i => i.ProductVariantId)
            .IsRequired();
        
        builder.Property(i => i.WarehouseId)
            .IsRequired();
        
        builder.Property(i => i.MovementType)
            .IsRequired();
    }
}