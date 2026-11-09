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
            .IsRequired();

        builder.Property(l => l.WarehouseId)
            .HasMaxLength(50);
        
        builder.Property(l => l.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(l => l.IsActive);
    }
}