using WarehouseManagement.Application.Common.Interfaces;

namespace WarehouseManagement.Application.Features.ProductVariant.Create;

public sealed record CreateVariantCommand(
    string Name,
    long CostPrice,
    long SalePrice,
    string? Barcode,
    string? Sku
) : ICommand<Guid>;