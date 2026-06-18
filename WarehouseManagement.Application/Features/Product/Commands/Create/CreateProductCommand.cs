using MediatR;

namespace WarehouseManagement.Application.Features.Product.Commands.Create;

public record CreateProductCommand : IRequest<Guid>
{
    // Khai báo các property input từ client gửi lên:
    public Guid PublicId { get; init; }
    public string? Sku { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }
    public decimal CostPrice { get; init; }
    public decimal SalePrice { get; init; }
    public string? BarCode { get; init; }
    public int? CategoryId { get; init; }
    public bool IsActive { get; init; }
}