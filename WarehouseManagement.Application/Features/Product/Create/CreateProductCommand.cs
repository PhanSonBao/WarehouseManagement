using MediatR;
using WarehouseManagement.Application.Features.ProductVariant.Create;

namespace WarehouseManagement.Application.Features.Product.Create;

public sealed record CreateProductCommand(
    string Name,
    string? Description,
    int CategoryId,
    int BrandId,
    bool IsActive,
    List<CreateVariantCommand> Variants
) : IRequest<Guid>;