namespace WarehouseManagement.Application.Features.Product.Queries.GetById;

internal static class ProductMapping
{
    internal static ProductDto ToDto(this Domain.Entities.Product p) => new(
        PublicId: p.PublicId,
        Sku: p.Sku,
        Name: p.Name,
        Description: p.Description,
        CostPrice: p.CostPrice,
        SalePrice: p.SalePrice,
        Barcode: p.Barcode,
        CategoryPublicId: p.Category.PublicId,
        BrandId: p.BrandId,
        IsActive: p.IsActive
    );
}