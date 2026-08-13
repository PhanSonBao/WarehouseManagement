using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Interfaces;

public interface IInventoryRepository
{
    Task<InventoryItem?> GetByVariantWarehouseAsync(int variantId, int warehouseId,
        CancellationToken ct = default);
    Task AddAsync(InventoryItem item, CancellationToken ct = default);
    Task AddMovementAsync(StockMovement movement, CancellationToken ct = default);
}