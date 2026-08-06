using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Persistence;

namespace WarehouseManagement.Infrastructure.Repositories;

public class WarehouseRepository(AppDbContext dbContext) : IWarehouseRepository
{
    public async Task<Warehouse?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Warehouses
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<Warehouse?> GetByPublicIdAsync(Guid publicId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Warehouses
            .FirstOrDefaultAsync(w => w.PublicId == publicId, cancellationToken);
    }

    public async Task AddAsync(Warehouse warehouse, CancellationToken cancellationToken = default)
    {
        await dbContext.Warehouses.AddAsync(warehouse, cancellationToken);
    }
}