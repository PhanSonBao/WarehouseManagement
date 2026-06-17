namespace WarehouseManagement.Application.Features.Product.Queries.GetById;

internal static class ProductMapping
{
    internal static ProductDto ToDto(this Domain.Entities.Product p) => new(
        Id: p.Id,
        PublicId: p.PublicId,
        Sku: p.Sku,
        Name: p.Name,
        Description: p.Description,
        CostPrice: p.CostPrice,
        SalePrice: p.SalePrice,
        Barcode: p.Barcode,
        CategoryId: p.CategoryId,
        BrandId: p.BrandId,
        IsActive: p.IsActive
    );
}