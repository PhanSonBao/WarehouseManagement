namespace WarehouseManagement.Application.Features.Product.Queries.GetById;

public record ProductDto(
    int Id,
    Guid PublicId,
    string? Sku,
    string Name,
    string Description,
    decimal CostPrice,
    decimal SalePrice,
    string? Barcode,
    int? CategoryId,
    int? BrandId,
    bool IsActive
);