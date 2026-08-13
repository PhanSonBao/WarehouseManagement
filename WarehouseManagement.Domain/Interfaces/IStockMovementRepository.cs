using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Interfaces;

public interface IStockMovementRepository
{
    Task<StockMovement?> GetByIdAsync(int id, CancellationToken ct = default);
    Task AddAsync(StockMovement stockMovement, CancellationToken ct = default);
}