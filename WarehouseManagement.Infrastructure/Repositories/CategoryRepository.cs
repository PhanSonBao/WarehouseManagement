using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Persistence;

namespace WarehouseManagement.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext dbContext) => _dbContext = dbContext;

    // Lấy chi tiết danh mục theo Id
    public Task<Category?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id, ct);
    }

    // Lấy chi tiết danh mục theo publicId
    public async Task<Category?> GetByPublicIdAsync(Guid publicId, CancellationToken ct = default)
    {
        return await _dbContext.Categories
            .FirstOrDefaultAsync(c => c.PublicId == publicId, ct);
    }

    // Đọc danh sách danh mục
    public async Task<IEnumerable<Category>> GetListAsync(CancellationToken ct = default)
    {
        return await _dbContext.Categories.ToListAsync(ct);
    }

    // Thêm danh mục mới
    public async Task AddAsync(Category category, CancellationToken ct = default)
    {
        await _dbContext.Categories.AddAsync(category, ct);
    }
}