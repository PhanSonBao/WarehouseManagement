using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Category?> GetByPublicIdAsync(string publicId, CancellationToken ct = default);
    Task<IEnumerable<Category>> GetListAsync(CancellationToken ct = default);
    Task AddAsync(Category category, CancellationToken ct = default);
}