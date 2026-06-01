using MediatR;

namespace WarehouseManagement.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand: IRequest<Guid>
{
    // Khai báo các property input từ client gửi lên:
    public string Sku { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SalePrice { get; set; }
    public string? BarCode { get; set; }
    public Guid CategoryId { get; set; }
    public bool IsActive { get; set; }
}