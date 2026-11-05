using WarehouseManagement.Application.Common.Interfaces;
using WarehouseManagement.Application.Features.ProductVariant.Create;

namespace WarehouseManagement.Application.Features.Product.Create;

public sealed record CreateProductCommand(
    string Name,
    string? Description,
    Guid CategoryId,
    Guid BrandId,
    bool IsActive,
    List<CreateVariantCommand> Variants
) : ICommand<Guid>;