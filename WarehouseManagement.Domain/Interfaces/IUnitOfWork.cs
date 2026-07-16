namespace WarehouseManagement.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    // Lưu tất cả thay đổi, trả về số rows affected
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    // Bắt đầu transaction
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    
    // Xác nhận transaction (ghi vào DB)
    Task CommitAsync(CancellationToken cancellationToken = default);
    
    // Hủy transaction nếu có lỗi và roll back về dữ liệu cũ
    Task RollbackAsync(CancellationToken cancellationToken = default);
}