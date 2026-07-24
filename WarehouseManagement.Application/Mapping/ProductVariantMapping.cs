using WarehouseManagement.Application.DTO;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Application.Mapping;

internal static class ProductVariantMapping
{
    internal static ProductVariantDto ToDto(this ProductVariant pv) => new(
        PublicId: pv.PublicId,
        Sku: pv.Sku,
        CostPrice: pv.CostPrice,
        SalePrice: pv.SalePrice,
        Barcode: pv.Barcode
    );
}