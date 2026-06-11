using MediatR;

namespace WarehouseManagement.Application.Features.Products.Commands.CreateProduct;

public record CreateCommand : IRequest<Guid>
{
    // Khai báo các property input từ client gửi lên:
    public string Sku { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }
    public decimal CostPrice { get; init; }
    public decimal SalePrice { get; init; }
    public string? BarCode { get; init; }
    public Guid CategoryId { get; init; }
    public bool IsActive { get; init; }
}