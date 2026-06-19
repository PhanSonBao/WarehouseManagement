using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    // Fluent API
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Table Name
        builder.ToTable("Categories");
        
        // Primary key is Id
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .UseIdentityColumn(); // Unique Identity (1 ,1)
        
        // PublicId
        builder.HasIndex(c => c.PublicId)
            .IsUnique();
        builder.Property(c => c.PublicId)
            .ValueGeneratedNever()
            .IsRequired();
        
        // Name
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}