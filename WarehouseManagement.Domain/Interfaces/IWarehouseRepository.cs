using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Interfaces;

public interface IWarehouseRepository
{
    Task<Warehouse?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Warehouse?> GetByPublicIdAsync(Guid publicId, CancellationToken ct = default);
    Task AddAsync(Warehouse warehouse, CancellationToken ct = default);
}