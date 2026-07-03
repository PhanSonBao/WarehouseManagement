using MediatR;

namespace WarehouseManagement.Application.Features.Product.Commands.Create;

public record CreateProductCommand(
    Guid PublicId,
    string Name,
    string Sku,
    string? Description,
    decimal CostPrice,
    decimal SalePrice,
    string? BarCode,
    int CategoryId,
    bool IsActive
) : IRequest<Guid>;