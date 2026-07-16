using MediatR;

namespace WarehouseManagement.Application.Features.Product.Update;

public abstract record UpdateProductCommand(
    int Id,
    Guid PublicId,
    string Sku,
    string Name,
    decimal CostPrice,
    decimal SalePrice,
    int CategoryId,
    bool IsActive
) : IRequest<Unit>;