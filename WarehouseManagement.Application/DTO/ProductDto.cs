namespace WarehouseManagement.Application.DTO;

public record ProductDto(
    string PublicId,
    string Name,
    string? Description,
    int CategoryId,
    int BrandId,
    bool IsActive,
    List<ProductVariantDto> Variants
);