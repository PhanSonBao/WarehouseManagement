using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.Persistence.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        // Table Name
        builder.ToTable("Location");
        
        // Properties
        builder.HasKey(l => l.LocationId);
        builder.Property(l => l.LocationId)
            .HasMaxLength(50)
            .IsRequired()
            .IsUnicode(false);

        builder.Property(l => l.ZoneId)
            .HasMaxLength(50)
            .IsRequired()
            .IsUnicode(false);
        
        builder.Property(l => l.Code)
            .HasMaxLength(50)
            .IsRequired()
            .IsUnicode(false);
        
        builder.Property(l => l.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(l => l.LocationType)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(l => l.MaxWeight)
            .HasPrecision(18, 3);

        builder.Property(l => l.MaxVolume)
            .HasPrecision(18, 3);

        builder.Property(l => l.IsBlocked)
            .HasDefaultValue(false);

        builder.Property(l => l.IsActive)
            .HasDefaultValue(true);
        
        builder.Property(l => l.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);
        
        // FK
        builder.HasOne(l => l.Zone)
            .WithMany(l => l.Locations)
            .HasForeignKey(l => l.ZoneId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}