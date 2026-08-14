using MediatR;
using WarehouseManagement.Application.Common.Interfaces;

namespace WarehouseManagement.Application.Features.ProductVariant.Create;

public sealed record CreateVariantCommand(
    string Name,
    int ProductId,
    long CostPrice,
    long SalePrice,
    string? Barcode,
    string? Sku
) : ICommand<Guid>;