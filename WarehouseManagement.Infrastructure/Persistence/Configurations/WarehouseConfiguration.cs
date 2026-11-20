using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.Persistence.Configurations;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        // Table Name
        builder.ToTable("Warehouse");
        
        // Primary key
        builder.HasKey(x => x.WarehouseId);
        builder.Property(x => x.WarehouseId)
            .HasMaxLength(50)
            .IsRequired()
            .IsUnicode(false);

        builder.Property(x => x.Code)
            .HasMaxLength(50)
            .IsRequired()
            .IsUnicode(false);
        builder.HasIndex(x => x.Code)
            .IsUnique();
        
        builder.Property(x => x.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(x => x.Address)
            .HasMaxLength(500);
        
        builder.Property(x => x.Description)
            .HasMaxLength(500);
        
        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.Property(x => x.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);
    }
}