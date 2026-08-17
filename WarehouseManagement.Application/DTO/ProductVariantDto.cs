namespace WarehouseManagement.Application.DTO;

public record ProductVariantDto
(
    Guid PublicId,
    string Name,
    long CostPrice,
    long SalePrice,
    string? Barcode,
    string? Sku
);