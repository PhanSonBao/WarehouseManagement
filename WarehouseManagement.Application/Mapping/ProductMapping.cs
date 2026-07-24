using WarehouseManagement.Application.DTO;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Application.Mapping;

internal static class ProductMapping
{
    internal static ProductDto ToDto(this Product p) => new(
        PublicId: p.PublicId,
        Name: p.Name,
        Description: p.Description,
        CategoryId: p.Category.Id,
        BrandId: p.BrandId,
        IsActive: p.IsActive
    );
}