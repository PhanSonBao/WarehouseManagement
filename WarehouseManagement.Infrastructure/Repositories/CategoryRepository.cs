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
    public Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
    
    // Đọc danh sách danh mục
    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Categories.ToListAsync(cancellationToken);
    }
    
    // Thêm danh mục mới
    public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
    {
        await _dbContext.Categories.AddAsync(category, cancellationToken);
    }
    
    // Lưu thay đổi
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}