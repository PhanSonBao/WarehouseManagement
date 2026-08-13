namespace WarehouseManagement.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    // Lưu tất cả thay đổi, trả về số rows affected
    Task<int> SaveChangesAsync(CancellationToken ct = default);
    
    // Bắt đầu transaction
    Task BeginTransactionAsync(CancellationToken ct = default);
    
    // Xác nhận transaction (ghi vào DB)
    Task CommitAsync(CancellationToken ct = default);
    
    // Hủy transaction nếu có lỗi và roll back về dữ liệu cũ
    Task RollbackAsync(CancellationToken ct = default);
}