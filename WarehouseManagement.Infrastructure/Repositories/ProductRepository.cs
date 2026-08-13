using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Persistence;

namespace WarehouseManagement.Infrastructure.Repositories;

public class ProductRepository(AppDbContext dbContext) : IProductRepository
{
    public async Task<Product?> GetByIdAsync(int id, CancellationToken ct = default)
        => await dbContext.Products
            .Include(p => p.Category)
            .Include(p => p.Variants)
            .FirstOrDefaultAsync(p => p.Id == id, ct);

    public async Task<Product?> GetByPublicIdAsync(Guid publicId, CancellationToken ct = default)
    {
        return await dbContext.Products
            .Include(p => p.Category)
            .Include(p => p.Variants)
            .FirstOrDefaultAsync(p => p.PublicId == publicId, ct);
    }

    // Lấy tất cả sản phẩm có IsActive = true
    public async Task<IEnumerable<Product>> GetListAsync(CancellationToken ct = default)
        => await dbContext.Products
            .Include(p => p.Category)
            .Include(p => p.Variants)
            .Where(p => p.IsActive)
            .ToListAsync(ct);

    // Thêm sản phẩm mới
    public async Task AddAsync(Product product, CancellationToken ct = default)
    {
        await dbContext.Products.AddAsync(product, ct);
    }
}