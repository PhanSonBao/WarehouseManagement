namespace WarehouseManagement.Application.DTO;

public record ProductVariantDto
(
    string PublicId,
    string Name,
    long CostPrice,
    long SalePrice,
    string? Barcode,
    string? Sku
);