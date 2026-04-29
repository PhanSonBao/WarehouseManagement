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
        // Đặt primary key là Id
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);
        builder.Property(p => p.Name);
        // SKU: required, max 50 ký tự
        // Tạo unique index cho SKU (không được trùng)


        // Name: required, max 200 ký tự


        // Barcode: không required, max 100 ký tự
        // Tạo index cho Barcode (để lookup nhanh khi scan)


        // CostPrice và SalePrice: kiểu int


        // Khai báo quan hệ với Category (HasOne/WithMany)
        // Khai báo quan hệ với Brand nếu có
    }
}