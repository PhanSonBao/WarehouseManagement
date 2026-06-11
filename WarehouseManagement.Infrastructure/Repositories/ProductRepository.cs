using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Persistence;

namespace WarehouseManagement.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;
    
    // Inject AppDbContext qua constructor
    public ProductRepository(AppDbContext dbContext) => _dbContext = dbContext;

    // Lấy Sản phẩm theo Id
    public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => _dbContext.Products
            .Include(p => p.Variants)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

    // Lấy tất cả sản phẩm có IsActive = true
    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Products
            .Where(p => p.IsActive)
            .ToListAsync(cancellationToken);

    // Thêm
    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _dbContext.Products.AddAsync(product, cancellationToken);
    }

    // Lưu thay đổi
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}