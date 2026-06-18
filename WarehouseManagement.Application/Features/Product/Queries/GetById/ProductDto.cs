namespace WarehouseManagement.Application.Features.Product.Queries.GetById;

public record ProductDto(
    Guid PublicId,
    string? Sku,
    string Name,
    string Description,
    decimal CostPrice,
    decimal SalePrice,
    string? Barcode,
    Guid CategoryPublicId,
    int? BrandId,
    bool IsActive
);