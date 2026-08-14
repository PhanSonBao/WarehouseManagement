using WarehouseManagement.Application.Common.Interfaces;
using WarehouseManagement.Application.Features.ProductVariant.Create;

namespace WarehouseManagement.Application.Features.Product.Create;

public sealed record CreateProductCommand(
    string Name,
    string? Description,
    int CategoryId,
    int BrandId,
    bool IsActive,
    List<CreateVariantCommand> Variants
) : ICommand<Guid>;