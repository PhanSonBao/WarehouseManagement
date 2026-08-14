using MediatR;

namespace WarehouseManagement.Application.Common.Interfaces;

/// <summary>
/// Marker interface: đánh dấu request nào là command (ghi dữ liệu),
/// để TransactionBehavior chỉ bọc các request này, không bọc Query
/// </summary>
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}