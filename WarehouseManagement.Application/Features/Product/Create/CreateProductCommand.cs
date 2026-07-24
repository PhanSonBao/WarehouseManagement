using MediatR;

namespace WarehouseManagement.Application.Features.Product.Create;

public record CreateProductCommand(
    Guid PublicId,
    string Name,
    string Sku,
    string? Description,
    long CostPrice,
    long SalePrice,
    string? BarCode,
    int CategoryId,
    bool IsActive
) : IRequest<Guid>;