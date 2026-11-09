using WarehouseManagement.Application.Common.Interfaces;

namespace WarehouseManagement.Application.Features.ProductVariant.Create;

public sealed record CreateVariantCommand(
    string Name,
    int ProductId,
    string UnitId,
    long CostPrice,
    long SalePrice,
    string? Barcode,
    string? Sku
) : ICommand<string>;