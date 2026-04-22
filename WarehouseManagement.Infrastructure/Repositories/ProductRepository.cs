using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Persistence;

namespace WarehouseManagement.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext) => _dbContext = dbContext;

    public Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken)!;

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Products.ToListAsync(cancellationToken);

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _dbContext.Products.AddAsync(product, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}