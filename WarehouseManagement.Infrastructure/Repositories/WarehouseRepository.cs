using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Persistence;

namespace WarehouseManagement.Infrastructure.Repositories;

public class WarehouseRepository(AppDbContext dbContext) : IWarehouseRepository
{
    public async Task<Warehouse?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await dbContext.Warehouses
            .FirstOrDefaultAsync(w => w.Id == id, ct);
    }

    public async Task<Warehouse?> GetByPublicIdAsync(Guid publicId, CancellationToken ct = default)
    {
        return await dbContext.Warehouses
            .FirstOrDefaultAsync(w => w.PublicId == publicId, ct);
    }

    public async Task AddAsync(Warehouse warehouse, CancellationToken ct = default)
    {
        await dbContext.Warehouses.AddAsync(warehouse, ct);
    }
}