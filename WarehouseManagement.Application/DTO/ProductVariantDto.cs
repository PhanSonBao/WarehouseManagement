namespace WarehouseManagement.Application.DTO;

public record ProductVariantDto
(
    Guid PublicId,
    decimal CostPrice,
    decimal SalePrice,
    string? Barcode,
    string? Sku
);