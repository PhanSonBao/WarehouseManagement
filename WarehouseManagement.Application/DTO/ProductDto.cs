namespace WarehouseManagement.Application.DTO;

public record ProductDto(
    string PublicId,
    string Name,
    string? Description,
    string BrandId,
    int CategoryId,
    bool IsActive,
    List<ProductVariantDto> Variants
);