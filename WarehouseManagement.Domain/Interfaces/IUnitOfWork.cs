namespace WarehouseManagement.Domain.Interfaces;

public interface IUnitOfWork
{
    // Method SaveChangesAsync — lưu tất cả thay đổi, trả về số rows affected
    // Method BeginTransactionAsync — bắt đầu transaction
    // Method CommitAsync — xác nhận transaction (ghi vào DB)
    // Method RollbackAsync — hủy transaction nếu có lỗi
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}