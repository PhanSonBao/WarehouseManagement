namespace WarehouseManagement.Application.Features.Products.Queries.GetById;

public record ProductDto(
    Guid Id,
    string Sku,
    string Name,
    string Description,
    decimal CostPrice,
    decimal SalePrice,
    string? Barcode,
    Guid? CategoryId,
    Guid? BrandId,
    bool IsActive
);