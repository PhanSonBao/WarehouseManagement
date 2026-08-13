using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Product?> GetByPublicIdAsync(Guid publicId, CancellationToken ct = default);
    Task<IEnumerable<Product>> GetListAsync(CancellationToken ct = default);
    Task AddAsync(Product product, CancellationToken ct = default);
}