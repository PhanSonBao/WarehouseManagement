using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // Db set
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<StockMovement> StockMovements => Set<StockMovement>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();

    // Load all classes Configuration classes
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
