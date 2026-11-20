using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.Persistence.Configurations;

public class ZoneConfiguration : IEntityTypeConfiguration<Zone>
{
    public void Configure(EntityTypeBuilder<Zone> builder)
    {
        // Table Name
        builder.ToTable("Zone");
        
        // PK
        builder.HasKey(x => x.ZoneId);
        builder.Property(x => x.ZoneId)
            .HasMaxLength(50)
            .IsRequired()
            .IsUnicode(false);
        
        builder.Property(x => x.WarehouseId)
            .HasMaxLength(50)
            .IsRequired()
            .IsUnicode(false);

        builder.Property(x => x.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(x => x.ZoneType)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);
        
        builder.Property(x => x.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(x => x.UpdatedAt);
        
        // FK
        builder.HasOne(x => x.Warehouse)
            .WithMany(x => x.Zones)
            .HasForeignKey(x => x.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}