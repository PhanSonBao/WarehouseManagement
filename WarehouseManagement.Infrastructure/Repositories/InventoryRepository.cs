using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Persistence;

namespace WarehouseManagement.Infrastructure.Repositories;

public class InventoryRepository(AppDbContext dbContext) : IInventoryRepository
{
    public async Task<InventoryItem?> GetByVariantWarehouseAsync(int variantId, int warehouseId, CancellationToken ct = default)
    {
        return await dbContext.InventoryItems
            .Where(i => i.VariantId == variantId && i.WarehouseId == warehouseId)
            .FirstOrDefaultAsync(ct);
    }
    
    public async Task AddAsync(InventoryItem item, CancellationToken ct = default)
    {
        await dbContext.AddAsync(item, ct);
    }

    public async Task AddMovementAsync(StockMovement movement, CancellationToken ct = default)
    {
        await dbContext.StockMovements.AddAsync(movement, ct);
    }
}