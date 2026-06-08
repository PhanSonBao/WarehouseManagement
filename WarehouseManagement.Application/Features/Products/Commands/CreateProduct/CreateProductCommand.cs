using MediatR;

namespace WarehouseManagement.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<Guid>
{
    // Khai báo các property input từ client gửi lên:
    public string Sku;
    public string Name;
    public string? Description;
    public decimal CostPrice;
    public decimal SalePrice;
    public string? BarCode;
    public Guid CategoryId;
    public bool IsActive;
}