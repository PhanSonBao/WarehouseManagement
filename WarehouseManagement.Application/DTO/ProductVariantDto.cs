namespace WarehouseManagement.Application.DTO;

public record ProductVariantDto
(
    Guid PublicId,
    long CostPrice,
    long SalePrice,
    string? Barcode,
    string? Sku
);