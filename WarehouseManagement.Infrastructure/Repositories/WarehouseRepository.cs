using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Persistence;

namespace WarehouseManagement.Infrastructure.Repositories;

public class WarehouseRepository(AppDbContext dbContext) : IWarehouseRepository
{
    public async Task<Warehouse?> GetByIdAsync(string warehouseId, CancellationToken ct = default)
    {
        return await dbContext.Warehouses
            .FirstOrDefaultAsync(w => w.WarehouseId == warehouseId, ct);
    }

    public async Task AddAsync(Warehouse warehouse, CancellationToken ct = default)
    {
        await dbContext.Warehouses.AddAsync(warehouse, ct);
    }
}