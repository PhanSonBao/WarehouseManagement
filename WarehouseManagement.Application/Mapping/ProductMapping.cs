using WarehouseManagement.Application.DTO;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Application.Mapping;

internal static class ProductMapping
{
    internal static ProductDto ToDto(this Product p) => new(
        Id: p.Id,
        PublicId: p.PublicId,
        Name: p.Name,
        Description: p.Description,
        CategoryId: p.CategoryId,
        BrandId: p.BrandId,
        IsActive: p.IsActive,
        Variants: new List<ProductVariantDto>()
    );
}