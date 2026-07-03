using MediatR;

namespace WarehouseManagement.Application.Features.Product.Commands.Update;

public record UpdateProductCommand(
    Guid PublicId,
    string Sku,
    string Name,
    decimal CostPrice,
    decimal SalePrice,
    int CategoryId,
    bool IsActive
) : IRequest<Unit>;