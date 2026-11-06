using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Interfaces;

public interface IWarehouseRepository
{
    Task<Warehouse?> GetByIdAsync(string warehouseId, CancellationToken ct = default);
    Task AddAsync(Warehouse warehouse, CancellationToken ct = default);
}